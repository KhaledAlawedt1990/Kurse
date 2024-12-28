using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EmailAndSMSMethode
{
    public class clsParfümSucheService
    {
        public static async Task<string> SendMessageToServerAsync(string message)
        {
            string result = string.Empty;
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    string serverIP = "192.168.178.150"; // IP-Adresse des Servers
                    int port = 5000;
                    // Verbindung zum Server herstellen
                    await client.ConnectAsync(serverIP, port);

                    // Nachricht senden
                    NetworkStream stream = client.GetStream();
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(messageBytes, 0, messageBytes.Length);

                    // Antwort vom Server lesen
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    result = response; // Antwort des Servers zurückgeben
                }
            }
            catch (Exception ex)
            {
                return $"Fehler: {ex.Message}"; // Fehlerbehandlung
            }
            return result;
        }
        public static void RequestService(string request)
        {
            try
            {
                string serverIP = "192.168.178.150"; // IP-Adresse des Servers
                int port = 5000;

                TcpClient client = new TcpClient(serverIP, port);
                if (client.Connected)
                {
                    //Console.WriteLine("Mit dem Server verbunden...");

                    // Anfrage senden

                    byte[] requestBytes = Encoding.UTF8.GetBytes(request);
                    NetworkStream stream = client.GetStream();
                    stream.Write(requestBytes, 0, requestBytes.Length);

                    // Antwort empfangen
                    //byte[] responseBytes = new byte[1024];
                    //int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
                    //string response = Encoding.UTF8.GetString(responseBytes, 0, bytesRead);


                }

               // Console.WriteLine($"Antwort vom Server: {response}");

                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
    }
}
