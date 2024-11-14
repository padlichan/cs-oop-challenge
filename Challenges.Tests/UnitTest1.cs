using FluentAssertions;
using Humanizer;
using System.Security.Cryptography.X509Certificates;

namespace Challenges.Tests
{
    public class Tests
    {
        [Test]
        public void _1UserPropertyTest()
        {
            User testUser = new User("test", "test@northcoders.com");
            testUser.Username.Should().Be("test");
            testUser.Email.Should().Be("test@northcoders.com");
        }

        [Test]
        public void _2BalanceTest()
        {
            User testUser = new User("test", "test@northcoders.com");
            testUser.Balance.Should().Be(0);
        }


        [Test]
        public void _3UpdateBalanceTest()
        {
            User testUser = new User("test", "test@northcoders.com");
            testUser.UpdateBalance(55);
            testUser.Balance.Should().Be(55);
            testUser.UpdateBalance(-5);
            testUser.Balance.Should().Be(50);
        }


        [Test]
        public void _4AccountsCreatedTest()
        {
            User.ResetAccountsCount();
            User.AccountsCreated.Should().Be(0);
            new User("test1", "test1@northcoders.com");
            User.AccountsCreated.Should().Be(1);
            new User("test2", "test2@northcoders.com");
            User.AccountsCreated.Should().Be(2);
        }


        [Test]
        public void _5ItemPropertyTest()
        {
            Item testItem = new Item("testUser", "test", 10, "testing it out");
            testItem.OwnerId.Should().Be("testUser");
            testItem.Name.Should().Be("test");
            testItem.Price.Should().Be(10);
            testItem.Description.Should().Be("testing it out");

            testItem.OwnerId = "newUser";
            testItem.OwnerId.Should().Be("newUser");

            testItem.Name = "new name";
            testItem.Name.Should().Be("new name");

            testItem.Price = 20;
            testItem.Price.Should().Be(20);

            testItem.Description = "new description";
            testItem.Description.Should().Be("new description");
        }


        [Test]
        public void _6ListItemTest()
        {
            User testUser = new User("testUser", "test@northcoders.com");

            Item firstItem = testUser.ListItem("testItemName1", 20, "test description1");
            Item firstItemForSale = testUser.ItemsForSale[0];
            firstItemForSale.Should().Be(firstItem);

            Item secondItem = testUser.ListItem("testItemName2", 20, "test description2");
            Item secondItemForSale = testUser.ItemsForSale[1];
            secondItemForSale.Should().Be(secondItem);
        }


        [Test]
        public void _7PurchaseItemTest()
        {
            User buyer = new User("testUser1", "test@northcoders.com");
            User seller = new User("testUser2", "test@northcoders.com");
            buyer.UpdateBalance(50);
            seller.ListItem("testItemName", 20, "test description");
            Item testItem = seller.ItemsForSale[0];
            buyer.PurchaseItem(testItem, seller).Should().Be(PurchaseResult.SUCCESS);
            buyer.Balance.Should().Be(30);
        }


        [Test]
        public void _8PurchaseItemWithoutFundsTest()
        {
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item = seller.ListItem("testItemName1", 20, "test description1");

            User buyer = new User("testUser2", "test2@northcoders.com");

            buyer.PurchaseItem(item, seller).Should().Be(PurchaseResult.INSUFFICIENT_FUNDS);

            buyer.UpdateBalance(50);

            buyer.PurchaseItem(item, seller).Should().Be(PurchaseResult.SUCCESS);
        }


        [Test]
        public void _8PurchaseOwnItemTest()
        {
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item = seller.ListItem("testItemName1", 20, "test description1");

            seller.PurchaseItem(item, seller).Should().Be(PurchaseResult.ALREADY_OWNED);
        }

        [Test]
        public void _9UnlistItemTest()
        {
            //Tests unlisting an item manually
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item1 = seller.ListItem("testItemName1", 20, "test description1");
            seller.ItemsForSale.Contains(item1).Should().Be(true);
            seller.UnlistItem(item1);
            seller.ItemsForSale.Contains(item1).Should().Be(false);

            //Tests unlisting when buying an item
            User buyer = new User("testUser2", "test2@northcoders.com");
            buyer.UpdateBalance(20);
            Item item2 = seller.ListItem("testItemName2", 5, "test description2");
            seller.ItemsForSale.Contains(item2).Should().Be(true);
            buyer.PurchaseItem(item2, seller);
            seller.ItemsForSale.Contains(item2).Should().Be(false);

        }

        [Test]
        public void _10UsernameIsNullTest()
        {
            string email = "test@Email.com";
            string[] usernames = new string[] { "testUser", "", null };
         
            List<bool> isErrorList = new List<bool>();

            foreach (string username in usernames)
            {
                try
                {
                    User user = new User(username, email);
                    isErrorList.Add(false);
                }

                catch (ArgumentException)
                {
                    isErrorList.Add(true);
                }
            }
                isErrorList.Should().Equal(new List<bool>() {false, true, true });
        }

        [Test]
        public void _10EmailFormatTest()
        {
            string username = "testUser1";
            string[] emails = new string[] {"", null, "asdfcvbnm", "abc.def@ghij-klm.nop" };

            List<bool> isErrorList = new List<bool>();
            foreach (string email in emails)
            {

            try
            {
                User user = new User(username, email);
                isErrorList.Add(false);
            }
            catch (ArgumentException)
            {
                    isErrorList.Add(true);
            }
            }
            isErrorList.Should().Equal(new List<bool> {true, true, true, false});
        }

        [Test]
        public void _11HumaniseDateTest()
        {
            Item item = new Item("testUser", "testItem", 14.99d, "testDescription");
            item.GetPrettyDateListed().Should().Be("now");
            item.SetDateListed(DateTime.Now.AddDays(-1));
            item.GetPrettyDateListed().Should().Be("yesterday");
            item.SetDateListed(DateTime.Now.AddDays(-18));
            item.GetPrettyDateListed().Should().Be("18 days ago");
        }

        [Test]
        public void _12IDTester()
        {
            User.ResetAccountsCount();
            Item.ResetItemsCount();

            for (int i = 0; i < 10; i++)
            {
                User user = new User($"testUser{i + 1}", $"test{i + 1}@email.com");
                user.UserID.Should().Be(i+1);
                Item item = new Item($"testUser{i + 1}", $"testItem{i + 1}", 14.99d, $"testDescription{i + 1}");
                item.ItemId.Should().Be(i + 1);
            }
        }

        [Test]
        public void _13ItemOwnerIsUserIDTester()
        {
            User user = new User("testUser", "testuser@email.com");
            Item item = user.ListItem("itemName", 15d, "itemDescription");
            item.OwnerId.Should().Be(user.UserID.ToString());
        }
    }
}
