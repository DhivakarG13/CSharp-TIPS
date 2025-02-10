using System;
using System.Collections.Generic;

List<CustomerData> CustomerList = new List<CustomerData>();

int CloseAppFlag = 0;
while (true)
{
    int MainPageChoice = UserInteraction.MainPage();

    List<int> MatchingIndexes = new List<int>();

    switch (MainPageChoice)
    {
        case 1: //Create a New Account.
            {
                Console.Clear();
                CustomerList.Add(UserInteraction.CreateNewAccount(CustomerList));
                Console.WriteLine("---------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Account Created");
                Console.ResetColor();
                Console.WriteLine("---------------------------");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                break;
            }
        case 2: //Check Your Account Details
        case 3: //WithDraw Cash
        case 4: //DepositCash
        case 5: //DeleteBankAccount
            {
                Console.Clear();
                int SearchByOption = UserInteraction.SearchAccountDialog(CustomerList); //All the operations in this Case starts by searching

                switch (SearchByOption)
                {
                    case 1:
                        {
                            MatchingIndexes.AddRange(AccountOperations.SearchByName(CustomerList));
                            Console.WriteLine("---------------------------");
                            if (MainPageChoice == 2)
                            {
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 2:
                        {
                            MatchingIndexes.AddRange(AccountOperations.SearchByAccountNumber(CustomerList));
                            Console.WriteLine("---------------------------");
                            if (MainPageChoice == 2)
                            {
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
                            break;
                        }
                }
                if (MatchingIndexes.Count == 0)//No results matches the search, thus case breaks.
                {
                    Console.WriteLine("No Searches Match your input");
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }

                switch (MainPageChoice) //Deleting BankAccount
                {
                    case 3: //Depositing Cash
                        {
                            Console.WriteLine("-----Initiating Cash Deposit-----");

                            int IndexToOperate = MatchingIndexes[0];

                            int accountTypeChoice = UserInteraction.GetAccountType();
                            Console.WriteLine("--------------------------------");

                            int Amount = UserInteraction.GetAmount();
                            Console.WriteLine("--------------------------------");

                            if (accountTypeChoice == 1)
                            {
                                CustomerList[IndexToOperate].SavingsAccount.Deposit(Amount);
                                Console.WriteLine("--------------------------------");

                            }
                            else
                            {
                                CustomerList[IndexToOperate].CheckingAccount.Deposit(Amount);
                                Console.WriteLine("--------------------------------");

                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        }


                    case 4: //WithDrawing Cash
                        {
                            Console.WriteLine("-----Initiating Cash Withdraw-----");

                            int IndexToOperate = MatchingIndexes[0];

                            int accountTypeChoice = UserInteraction.GetAccountType();
                            Console.WriteLine("--------------------------------");

                            int Amount = UserInteraction.GetAmount();
                            Console.WriteLine("--------------------------------");

                            if (accountTypeChoice == 1) //WithDraw from Savings Account
                            {
                                CustomerList[IndexToOperate].SavingsAccount.WithDraw(Amount);
                                Console.WriteLine("--------------------------------");

                            }
                            else // WithDraw from Checking Account
                            {
                                CustomerList[IndexToOperate].CheckingAccount.WithDraw(Amount);
                                Console.WriteLine("--------------------------------");

                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        }

                    case 5: //Deleting Account
                        {
                            Console.WriteLine("------ Deleting Account -----");
                            int IndexToDelete = MatchingIndexes[0];
                            CustomerList.RemoveAt(IndexToDelete);
                            Console.WriteLine("---------------------------");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Account Deleted");
                            Console.ResetColor();
                            Console.WriteLine("---------------------------");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        }
                }

                break;
            }
        case 6: //CloseApp
            {
                CloseAppFlag = 1;
                break;
            }

    }
    if (CloseAppFlag == 1)//Closing Application
    {
        break;
    }

}
