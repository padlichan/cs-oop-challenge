using Humanizer;

namespace Challenges
{
    public class Item
    {
        public static int ItemsCreated { get; private set; } = 0;
        public string OwnerId;
        public string Name;
        public double Price;
        public string Description;
        public DateTime DateListed;
        public int ItemId { get; init; }

        public Item(string ownerUserId, string name, double price, string description)
        {
            OwnerId = ownerUserId;
            Name = name;
            Price = price;
            Description = description;
            DateListed = DateTime.Now;
            ItemsCreated++;
            ItemId = ItemsCreated;
        }

        public string GetPrettyDateListed()
        {
            return DateListed.Humanize();
        }

        public void SetDateListed(DateTime dateTimeToSet)
        {
            DateListed = dateTimeToSet;
        }

        public static void ResetItemsCount()
        {
            ItemsCreated = 0;
        }
    }
}
