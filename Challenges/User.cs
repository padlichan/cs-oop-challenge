using System.IO.Compression;
using System.Text.RegularExpressions;

namespace Challenges
{
    public partial class User
    {
        //Properties
        public static int AccountsCreated { get; private set; }
        public string Username { get; }
        public string Email { get; }
        public double Balance { get; private set; }

        public List<Item> ItemsForSale { get; private set; } = [];

        public int UserID { get; init; }

        //Constructor
        public User(string username, string email)
        {
            if(username == "" || username == null) throw new ArgumentException("Username cannot be empty or null");
            string emailFormat = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9._%+-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, emailFormat)) throw new ArgumentException("Email must match email format");
            Username = username;
            Email = email;
            Balance = 0;
            AccountsCreated++;
            UserID = AccountsCreated;
        }

        //Methods
        public void UpdateBalance(double amount)
        {
            Balance += amount;
        }

        public static void ResetAccountsCount()
        {
            AccountsCreated = 0;
        }

        public Item ListItem(string name, double price, string description)
        {
            Item itemToList = new Item(this.UserID.ToString(), name, price, description);
            ItemsForSale.Add(itemToList);
            return itemToList;
        }

        public PurchaseResult PurchaseItem(Item itemToPurchase, User seller)
        {
            if (ItemsForSale.Contains(itemToPurchase)) return PurchaseResult.ALREADY_OWNED;
            if (itemToPurchase.Price > Balance) return PurchaseResult.INSUFFICIENT_FUNDS;
            UpdateBalance(-1 * itemToPurchase.Price);
            seller.UnlistItem(itemToPurchase);
            return PurchaseResult.SUCCESS;
        }

        public void UnlistItem(Item itemToUnlist)
        {
            if(ItemsForSale.Contains(itemToUnlist)) ItemsForSale.Remove(itemToUnlist);
            else Console.WriteLine("You're trying to unlist an item that is not listed.");
        }
    }

    public enum PurchaseResult
    {
        SUCCESS,
        INSUFFICIENT_FUNDS,
        ALREADY_OWNED
    }
}
