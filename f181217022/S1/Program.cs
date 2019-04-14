using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace S1
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 13000);
                
                server.Start();

                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    
                    NetworkStream stream = client.GetStream();
                    
                    while (client.Connected)
                    {
                        Byte[] bytes = new Byte[256];
                        stream.Read(bytes, 0, bytes.Length);
                        // Translate data bytes to a ASCII string.
                        String data = System.Text.Encoding.ASCII.GetString(bytes, 0, bytes.Length).Trim('\0');
                        Console.WriteLine("Command: " + data);

                        Process p = new Process();

                        p.StartInfo.FileName = "p1.exe";
                        p.StartInfo.Arguments = data;
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.CreateNoWindow = true;
                        p.Start();
                        
                        string output = p.StandardOutput.ReadToEnd();

                        Console.WriteLine("Process response: " + output);

                        stream.Write(Encoding.ASCII.GetBytes(output), 0, output.Length);

                        stream.Close();
                        client.Close();
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }
    }
}

