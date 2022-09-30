namespace Linq_Full
{
    public static class Three
    {
        public static void Content()
        {
            var list = new List<int>() { 1, 2, 3, 4 };

            //query syntex
            var s = from value in list
                    where value > 1
                    select value;

            foreach (var i in s)
            {
                Console.WriteLine(i);
            }

            // method syntex
            var methodsyn = list.Where(x => x > 2);
            foreach (var i in methodsyn)
            {
                Console.WriteLine(i);
            }
        }
    }
}