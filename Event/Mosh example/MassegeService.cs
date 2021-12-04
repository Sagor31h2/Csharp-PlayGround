using System;

namespace Mosh_example
{
    public class MassegeService
    {
        public void OnEncoded(object source,EventArgs eventArgs)
        {
            Console.WriteLine(" message is sending");
        }
    }
}
