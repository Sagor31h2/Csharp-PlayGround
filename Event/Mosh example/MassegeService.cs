using System;

namespace Mosh_example
{
    public class MassegeService
    {
        public void OnEncoded(object source,VideoEventArgs eventArgs)
        {
            Console.WriteLine("message is sending to"+ eventArgs.Video.Title);
        }
    }
}
