using System;

namespace Bank_ATM
{
    public class Program
    {
        static double balance = 5000.00;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mocking Bird Bank ATM");

            try
            {
                UserInterface();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Thank you for using Mocking Bird Bank.");
            }
        }

        static void UserInterface()
        {
            Console.WriteLine("Please choose from one of the following options:");
            Console.WriteLine("1) View Balance");
            Console.WriteLine("2) Withdraw Money");
            Console.WriteLine("3) Deposit Money");
            Console.WriteLine("4) Exit");

            string userSelection = Console.ReadLine();
            int actionSelection = Convert.ToInt32(userSelection);

            switch (actionSelection)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                default:
                    break;
            }
        }

        static void ViewBalance()
        {

        }

        static void WithdrawMoney()
        {

        }

        static void DepositMoney()
        {

        }

        static void Exit()
        {

        }

    }
}
