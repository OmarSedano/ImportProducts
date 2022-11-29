

using System;
using ImportProductsApp.Services.Contracts;

namespace ImportProductsApp.Services.Implementations
{
    public class Logs : ILogs
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
