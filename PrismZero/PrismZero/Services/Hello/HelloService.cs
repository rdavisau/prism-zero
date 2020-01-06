using System;

namespace PrismZero.Services.Hello
{
    public class HelloService : ServiceBase, IHelloService
    {
        public void SayHello()
        {
            Console.WriteLine("Hello!");
        }
    }
}