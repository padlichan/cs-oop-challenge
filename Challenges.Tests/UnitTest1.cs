using FluentAssertions;

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
        /*
        [Test]
        public void _2BalanceTest()
        {
            User testUser = new User("test", "test@northcoders.com");
            testUser.Balance.Should().Be(0);
        }
        */
        /*
        [Test]
        public void _3UpdateBalanceTest()
        {
            User testUser = new User("test", "test@northcoders.com");
            testUser.UpdateBalance(55);
            testUser.Balance.Should().Be(55);
            testUser.UpdateBalance(-5);
            testUser.Balance.Should().Be(50);
        }
        */
        /*
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
        */
        /*
        [Test]
        public void _5ItemPropertyTest()
        {
            Item testItem = new Item("testUser", "test", 10, "testing it out");
            testItem.Owner.Should().Be("testUser");
            testItem.Name.Should().Be("test");
            testItem.Price.Should().Be(10);
            testItem.Description.Should().Be("testing it out");

            testItem.Owner = "newUser";
            testItem.Owner.Should().Be("newUser");

            testItem.Name = "new name";
            testItem.Name.Should().Be("new name");

            testItem.Price = 20;
            testItem.Price.Should().Be(20);

            testItem.Description = "new description";
            testItem.Description.Should().Be("new description");
        }
        */
        /*
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
        */
        /*
        [Test]
        public void _7PurchaseItemTest()
        {
            User buyer = new User("testUser1", "test@northcoders.com");
            User seller = new User("testUser2", "test@northcoders.com");
            buyer.UpdateBalance(50);
            seller.ListItem("testItemName", 20, "test description");
            Item testItem = seller.ItemsForSale[0];
            buyer.PurchaseItem(testItem).Should().Be(PurchaseResult.SUCCESS);
            buyer.Balance.Should().Be(30);
        }
        */
        /*
        [Test]
        public void _9PurchaseItemWithoutFundsTest()
        {
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item = seller.ListItem("testItemName1", 20, "test description1");

            User buyer = new User("testUser2", "test2@northcoders.com");

            buyer.PurchaseItem(item).Should().Be(PurchaseResult.INSUFFICIENT_FUNDS);

            buyer.UpdateBalance(50);

            buyer.PurchaseItem(item).Should().Be(PurchaseResult.SUCCESS);
        }
        */
        /*
        [Test]
        public void _9PurchaseOwnItemTest()
        {
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item = seller.ListItem("testItemName1", 20, "test description1");

            seller.PurchaseItem(item).Should().Be(PurchaseResult.ALREADY_OWNED);
        }
        */
    }
}
