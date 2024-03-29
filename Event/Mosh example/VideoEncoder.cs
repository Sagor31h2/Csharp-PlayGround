﻿using System;
using System.Threading;

namespace Mosh_example
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
    public class VideoEncoder
    {
       public event EventHandler<VideoEventArgs> Videoencoded;
        public void Encode(Video video)
        {
            Console.WriteLine("encoding video");

            Thread.Sleep(3000);
            OnVideoencoded(video);

        }
        protected virtual void OnVideoencoded(Video video)
        {
            if (Videoencoded != null)
            {
                Videoencoded(this,new VideoEventArgs() { Video=video});
            }

        }

    }
}