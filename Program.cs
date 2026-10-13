namespace IceCream;
using MongoDB.Bson;
using MongoDB.Bson.IO;  
using MongoDB.Driver;
using IceCream.Data;
static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
       
}