using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;
using ClassLibrary;

try
{
    Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
    clientSocket.Connect(serverEndPoint);
    Console.WriteLine("Підключено до сервера.");

    byte[] buffer = new byte[256];
    int bytesRead = 0;
    StringBuilder response = new StringBuilder();

    do
    {
        bytesRead = clientSocket.Receive(buffer);
        response.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
    } while (bytesRead > 0);

    Product receivedProduct = JsonSerializer.Deserialize<Product>(response.ToString());
    Console.WriteLine("Отримано об'єкт Product:");
    Console.WriteLine(receivedProduct);

    clientSocket.Shutdown(SocketShutdown.Both);
    clientSocket.Close();
}
catch (Exception ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}