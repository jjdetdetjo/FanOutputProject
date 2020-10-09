using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using FanOutputLibrary;
using FanRestService.Controllers;
using Newtonsoft.Json;

namespace FanTCPServer
{
    class Server
    {
        public void Start()
        {
            TcpListener serverSocket = new TcpListener(4646);
            serverSocket.Start();
            using (TcpClient connectionSocket = serverSocket.AcceptTcpClient())
            {
                Console.WriteLine("Server is up and running");
                Stream ns = connectionSocket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                FanController controller = new FanController();

                while (true)
                {
                    string message1 = sr.ReadLine();
                    string message2 = sr.ReadLine();
                    Console.WriteLine("Recieved message: " + message1 + message2);

                    if (message1 == "HentAlle")
                    {
                        foreach (var fanoutput in controller.Get())
                        {
                            string outputString = JsonConvert.SerializeObject(fanoutput);
                            Console.WriteLine(outputString);
                        }
                    }
                    else if (message1 == "Hent")
                    {
                        if (int.TryParse(message2, out var number))
                        {
                            string outputString = JsonConvert.SerializeObject(controller.Get(number));
                            Console.WriteLine(outputString);
                        }
                        else
                        {
                            Console.WriteLine("Du angav ikke et tal, prøv igen");
                        }
                    }
                    else if (message1 == "Gem")
                    {
                        try
                        {
                            FanOutput output = JsonConvert.DeserializeObject<FanOutput>(message2);
                            try
                            {
                                controller.Post(output);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Du angav ikke en gyldig json string, prøv igen");
                        }
                    }
                    else if (message1 == "break")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Skriv enten: Hentalle + en tom besked, Hent + et tal efterfølgende, Gem + en json string efterfølgende");
                    }
                }

            }
        }
    }
}
