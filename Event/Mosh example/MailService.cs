using System;

namespace Mosh_example
{
    public class MailService
    {
        public void OnEncoded(object source , EventArgs e)
        {
            Console.WriteLine(" Mail is sending");

        }
    }
}
