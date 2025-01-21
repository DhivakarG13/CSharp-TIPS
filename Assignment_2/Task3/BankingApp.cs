

// Ignore Spelling: Validators

using System.Collections.Generic;
using System.Threading.Channels;
using Microsoft.VisualBasic;

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
                
                if (SearchByOption==1)
                {
                    MatchingIndexes.AddRange(UserInteraction.SearchByName(CustomerList));
                }
                else
                {
                    MatchingIndexes.AddRange(UserInteraction.SearchByAccountNumber(CustomerList));
                }

                if(MatchingIndexes.Count == 0)//No results matches the search, thus case breaks.
                {
                    Console.WriteLine("No Searches Match your input");
                    break;
                }

                if(MainPageChoice == 5) //Deleting BankAccount
                {
                    Console.WriteLine("------ Deleting Account -----");
                    int IndexToDelete = UserInteraction.GetIndexToOperate(MatchingIndexes);
                    CustomerList.RemoveAt(IndexToDelete);
                    Console.WriteLine("---------------------------");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Account Deleted");
                    Console.ResetColor();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }

                if (MainPageChoice == 3) //Depositing Cash
                {
                    Console.WriteLine("-----Initiating Cash Deposit-----");

                    int IndexToOperate = UserInteraction.GetIndexToOperate(MatchingIndexes);
                    Console.WriteLine("--------------------------------");

                    int accountTypeChoice = UserInteraction.GetAccountType();
                    Console.WriteLine("--------------------------------");

                    int Amount = UserInteraction.GetAmount();
                    Console.WriteLine("--------------------------------");

                    if (accountTypeChoice == 1)
                    {
                        CustomerList[IndexToOperate].SavingsAccountDeposit(Amount);
                        Console.WriteLine("--------------------------------");

                    }
                    else
                    {
                        CustomerList[IndexToOperate].CheckingAccountDeposit(Amount);
                        Console.WriteLine("--------------------------------");

                    }
                }


                if(MainPageChoice == 4) //WithDrawing Cash
                {
                    Console.WriteLine("-----Initiating Cash Withdraw-----");

                    int IndexToOperate = UserInteraction.GetIndexToOperate(MatchingIndexes);
                    Console.WriteLine("--------------------------------");

                    int accountTypeChoice = UserInteraction.GetAccountType();
                    Console.WriteLine("--------------------------------");

                    int Amount = UserInteraction.GetAmount();
                    Console.WriteLine("--------------------------------");

                    if (accountTypeChoice == 1) //WithDraw from Savings Account
                    {
                        CustomerList[IndexToOperate].SavingsAccountWithDrawl(Amount, 500);// 500 is the Minimum Balance
                        Console.WriteLine("--------------------------------");

                    }
                    else // WithDraw from Checking Account
                    {
                        CustomerList[IndexToOperate].CheckingAccountWithDrawl(Amount);
                        Console.WriteLine("--------------------------------");

                    }
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
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
