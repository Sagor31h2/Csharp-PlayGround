using System;
using System.Threading;

namespace Mosh_example
{
    public class VideoEncoder
    {
        public void Encode(Video video)
        {
            Console.WriteLine("encoding video");

            Thread.Sleep(300);
        }
    }
}