using System;
using Xunit;
using Bank_ATM;

namespace Bank_ATM_Unit_Test
{
    public class UnitTest1
    {
        [Fact]
        public void CanWithdrawMoneyLessThanBalance()
        {
            Program.balance = 5000.00;

            string testAmount = Convert.ToString(Program.WithdrawMoney(800.00));

            Assert.Equal("4200", testAmount);
        }

        [Fact]
        public void CanNotWithdrawMoneyMoreThanBalance()
        {
            Program.balance = 5000.00;

            string testAmount = Convert.ToString(Program.WithdrawMoney(8000.00));

            Assert.Equal("5000", testAmount);
        }
    }
}
