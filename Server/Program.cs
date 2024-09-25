using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;
using ClassLibrary;

Product product = new Product
{
    Name = "Laptop",
    Price = 1200.50m,
    Manufacturer = "TechCorp"
};

string jsonProduct = JsonSerializer.Serialize(product);

byte[] productData = Encoding.UTF8.GetBytes(jsonProduct);

Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 5000);

listener.Bind(endPoint);
listener.Listen(10);
Console.WriteLine("Сервер запущений. Очікування підключень...");

while (true)
{

    Socket clientSocket = listener.Accept();
    Console.WriteLine("Клієнт підключився.");

    clientSocket.Send(productData);
    Console.WriteLine($"Об'єкт {nameof(Product)} відправлено клієнту.");

    clientSocket.Shutdown(SocketShutdown.Both);
    clientSocket.Close();
}