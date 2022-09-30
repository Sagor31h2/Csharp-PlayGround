namespace Linq_Full
{
    public class employee
    {
        public string? Name { get; set; }
        public int Id { get; set; }
    }

    public static class Four
    {
        public static void Content()
        {
            var employee = new List<employee>()
            {
                new employee(){Name="Sagor", Id=1},

                new employee(){Name="Tusher",Id=2},
            };

            IEnumerable<employee> list = from iemp in employee
                                         where iemp.Id == 1
                                         select iemp;
            foreach (var item in list)
            {
                Console.WriteLine(item.Name + " " + item.Id);
            }

            Console.WriteLine("-----------------------------------");

            IQueryable<employee> query = employee.AsQueryable().Where(x => x.Id == 2);
            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " " + item.Id);
            }
        }
    }
}