namespace Mosh_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = " hellow video" };
            var VideoEncoder=new VideoEncoder();
            VideoEncoder.Encode(video);
            
        }
    }
}
