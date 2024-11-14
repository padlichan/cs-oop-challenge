namespace Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User testUser = new User("testname", "test@email.com");
            Item item = new Item("testUser", "testItem", 14.99d, "testDescription");
            Console.WriteLine(item.GetPrettyDateListed());
            item.SetDateListed(DateTime.Now.AddDays(-1));
            Console.WriteLine(item.GetPrettyDateListed());
            item.SetDateListed(DateTime.Now.AddDays(-18));
            Console.WriteLine(item.GetPrettyDateListed());


        }
    }
}
