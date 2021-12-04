namespace Mosh_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = " hellow video" };
            var VideoEncoder = new VideoEncoder();
            var mailService = new MailService();
            var massegeService = new MassegeService();
            VideoEncoder.Videoencoded += mailService.OnEncoded;
            VideoEncoder.Videoencoded += massegeService.OnEncoded;

            VideoEncoder.Encode(video);

        }
    }
}
