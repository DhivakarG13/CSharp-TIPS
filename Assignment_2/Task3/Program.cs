

// Ignore Spelling: Validators

using System.Collections.Generic;
using System.Threading.Channels;

List<CustomerData> CustomerList = new List<CustomerData>();
int CloseAppFlag = 0;
while (true)
{
    int MainPageChoice = UserInteraction.MainPage(); 
    switch (MainPageChoice)
    {
        case 1:
            {
                CustomerList.Add(UserInteraction.CreateNewAccount());
                break;
            }
        case 2:
        case 3:
        case 4:
        case 5:
            {
                int SearchByOption = UserInteraction.SearchAccountDialog(CustomerList);
                List<int> MatchingIndeces = new List<int>();
                if (SearchByOption==1)
                {
                    MatchingIndeces.Concat(UserInteraction.SearchByName( CustomerList));
                }
                else
                {
                    MatchingIndeces.Concat(UserInteraction.SearchByAccountNumber(CustomerList));
                }
                if(MatchingIndeces.Count == 0)
                {
                    Console.WriteLine("No Searches Match your input");
                    break;
                }
                if(MainPageChoice == 5)
                {
                    Console.WriteLine("Deleting Account");
                    int IndexToDelete = UserInteraction.GetIndexToOperate(MatchingIndeces);
                    CustomerList.RemoveAt(IndexToDelete);

                }
                if (MainPageChoice == 3)
                {
                    ConsoleWriter.PrintAccountTypeDialouge();
                    int IndexToOperate = UserInteraction.GetIndexToOperate(MatchingIndeces);
                    int accountTypeChoice = UserInteraction.GetAccountType();
                    int Amount = UserInteraction.GetAmount(); 
                    if(accountTypeChoice == 1)
                    {
                        CustomerList[IndexToOperate].SavingsAccountDeposit(Amount);
                    }
                    else
                    {
                        CustomerList[IndexToOperate].CheckingAccountDeposit(Amount);
                    }
                }
                if(MainPageChoice == 4)
                {
                    ConsoleWriter.PrintAccountTypeDialouge();
                    int IndexToOperate = UserInteraction.GetIndexToOperate(MatchingIndeces);
                    int accountTypeChoice = UserInteraction.GetAccountType();
                    int Amount = UserInteraction.GetAmount();
                    if (accountTypeChoice == 1)
                    {
                        CustomerList[IndexToOperate].SavingsAccountWithDrawl(Amount, 500);// 500 is the Minimum Balance
                    }
                    else
                    {
                        CustomerList[IndexToOperate].CheckingAccountWithDrawl(Amount);
                    }
                }
                break;
            }
        case 6://Delete Bank Account
            {
                CloseAppFlag = 1;
                break;
            }
    }
    if(CloseAppFlag == 1)
    {
        break;
    }

}
