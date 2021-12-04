using System;

namespace Mosh_example
{
    public class MailService
    {
        public void OnEncoded(object source , VideoEventArgs e)
        {
            Console.WriteLine(" Mail is sending to"+e.Video.Title);

        }
    }
}
