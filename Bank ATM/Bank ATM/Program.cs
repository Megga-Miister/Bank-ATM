using System;

namespace Bank_ATM
{
    public class Program
    {
        public static double balance = 5000.00;

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

        /// <summary>
        /// Displays ATM options and runs action chosen by user
        /// </summary>
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
                    ViewBalance();
                    AdditionalTransaction();
                    break;
                case 2:
                    WithdrawMoney(WithdrawRequest());
                    AdditionalTransaction();
                    break;
                case 3:
                    DepositMoney(DepositRequest());
                    AdditionalTransaction();
                    break;
                case 4:
                    Exit();
                    break;
                default:
                    Exit();
                    break;
            }
        }

        /// <summary>
        /// Displays the current balance 
        /// </summary>
        static void ViewBalance()
        {
            Console.WriteLine($"The current balance is: {balance}");

        }

        /// <summary>
        /// Withdraw transaction that deducts from the balance
        /// </summary>
        /// <param name="approvedWithdrawAmount"> Amount of money user wishes to withdraw that didn't hit any exceptions</param>
        /// <returns> Updated balance </returns>
        public static double WithdrawMoney(double approvedWithdrawAmount)
        {
            if(approvedWithdrawAmount > balance)
            {
                approvedWithdrawAmount = 0;
                balance = balance - approvedWithdrawAmount;
                return balance;
            }
            else
            {
                balance = balance - approvedWithdrawAmount;
                return balance;
            }   
        }

        /// <summary>
        /// Used to validate user's withdraw request in order to prevent balance overdraft
        /// </summary>
        /// <returns> An approved withdraw amount that can be deducted from balance</returns>
        static double WithdrawRequest()
        {
            double withdrawAmount = ConfirmTransactionAmount("withdraw");

            if (withdrawAmount > balance)
            {
                Console.WriteLine("Unable to withdraw more than current balance.");
                return withdrawAmount = 0;
            }
            else
            { 
                return withdrawAmount;
            }
        }

        /// <summary>
        /// Deposit transaction that will add to the balance
        /// </summary>
        /// <param name="approvedDepositAmount"> Amount of money user wishes to deposit that didn't hit any exceptions</param>
        /// <returns> Updated banlance</returns>
        public static double DepositMoney(double approvedDepositAmount)
        {
            if (approvedDepositAmount < 0)
            {
                approvedDepositAmount = 0;
                balance = balance + approvedDepositAmount;
                return balance;
            }
            else
            {
                balance = balance + approvedDepositAmount;
                return balance;
            }
        }

        /// <summary>
        /// Used to validate user's deposit request in order to prevent negative numbers from being added to balance
        /// </summary>
        /// <returns> An approved deposit amount that can be added to the balance</returns>
        static double DepositRequest()
        {
            double depositAmount = ConfirmTransactionAmount("deposit");

            if (depositAmount < 0)
            {
                Console.WriteLine("Unable to deposit a negative amount.");
                return depositAmount = 0;
            }
            else
            {
                return depositAmount;
            }
        }

        /// <summary>
        /// Triggers the program closing
        /// </summary>
        static void Exit()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Prompts user to answer if they would like to complete an addtional transaction from the main menu
        /// </summary>
        static void AdditionalTransaction()
        {
            Console.WriteLine("Would you like to conduct another transaction? (Y/N)");

            string userResponse = Console.ReadLine();
            string userDecision = userResponse.ToUpper();

            if(userDecision == "Y")
            {
                UserInterface();
            }
            else if(userDecision == "N")
            {
                Exit();
            }
            else
            {
                UserInterface();
            }
        }

        /// <summary>
        /// Prompts user to enter amount they would like to use in transaction
        /// </summary>
        /// <param name="transcationType">Withdraw or Deposit</param>
        /// <returns>Amount user is trying to transact</returns>
        static double ConfirmTransactionAmount(string transcationType)
        {
            Console.WriteLine($"Please enter a dollar amount to {transcationType}");

            try
            {
                string amount = Console.ReadLine();
                double transactionAmount = Convert.ToDouble(amount);
                return transactionAmount;
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
                throw;
            }

            
        }
    }
}
