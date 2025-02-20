namespace Simple_Calculator
{
    public static class UserDataValidate
    {
        public static bool ValidateChoice(int choice, int totalOptions)
        {
            if (choice > 0 && choice <= totalOptions)
            {
                return true;
            }
            return false;
        }
    }
}