using System;
using System.Threading;

namespace Mosh_example
{
    public class VideoEncoder
    {
        public delegate void VideoEventHandler(object source, EventArgs eventArgs);
        public event VideoEventHandler Videoencoded;
        public void Encode(Video video)
        {
            Console.WriteLine("encoding video");

            Thread.Sleep(3000);
            OnVideoencoded();

        }
        protected virtual void OnVideoencoded()
        {
            if (Videoencoded != null)
            {
                Videoencoded(this, EventArgs.Empty);
            }

        }

    }
}