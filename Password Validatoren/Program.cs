namespace Password_Validatoren
{
    internal class Program
    {
        static string password;
        static void Main(string[] args)
        {
            Program.Gui();
            Console.ReadLine();
        }

        static void Gui()
        {
            
            Console.WriteLine("\r\nIndtast dit password");
            Program.Controller();
            //Checks if the password are within the min and max amount of chars
            //if false, then it gives the user a chance to write a new password by running Gui again
            if (!MinMaxChar(password))
            {
                Console.WriteLine("Passwordet skal være på min 12 og max 64 tegn");
                Program.Gui();
            }
            //checks for uppercase and lowercase
            else if (!UpperLower(password))
            {
                Console.WriteLine("Passwordet skal indeholde både store og små tegn");
                Program.Gui();
            }
            //Checks for numbers
            else if (!Number(password))
            {
                Console.WriteLine("Passwordet skal indeholde numre");
                Program.Gui();
            }
            //Checks for special chars
            else if (!SpecialChars(password))
            {
                Console.WriteLine("Passwordet skal indeholde et eller flere special tegn");
                Program.Gui();
            }
            //Checks how strong the password is
            else
            {
                //The password is not strong enough so it runs the Gui again
                if (Has4InARow(password) && NumbersInASeq(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Passwordet er ikke stærkt nok");
                    Console.ResetColor();
                    Program.Gui();
                }
                //The password is ok but still weak
                else if (Has4InARow(password) || NumbersInASeq(password))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Passwordet er OK, men betragtes som svagt");
                    Console.ResetColor();
                }
                //the password is ok
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Passwordet er OK");
                    Console.ResetColor();
                }
            }
        }

        static void Moddellayer()
        {
            //sets password to be what the user inputs
            password = Console.ReadLine();
        }

        static void Controller()
        {
            Program.Moddellayer();
            //run the different bools to check the password requirements are met
            Program.MinMaxChar(password);
            Program.UpperLower(password);
            Program.Number(password);
            Program.SpecialChars(password);
        }
        static bool MinMaxChar(string password)
        {
            //checks if the chars in the password is between 12 and 64
            if (password.Length > 11 && password.Length < 65)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool UpperLower(string password)
        {
            //Checks for uppercase and lowercase chars with a foreach loop to loop through all chars in the password string
            bool upper = false;
            bool lower = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    upper = true;
                }
                else if (char.IsLower(c))
                {
                    lower = true;
                }
            }
            //returns true if theres both lower and uppercase chars
            if (upper == true && lower == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool Number(string password)
        {
            //checks for numbers through a foreach loop, returns true if there's a number
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        static bool SpecialChars(string password)
        {
            //checks for any char that isn't a letter or digit, returns true if there is one
            return password.Any(ch => !Char.IsLetterOrDigit(ch));
        }
        static bool Has4InARow(string password)
        {
            //uses a for loop to check if there't a point in the string with the same char 4 times in a row, returns true if there is
            for (int i = 0; i < password.Length-3; i++)
            {
                if (password[i] == password[i+1] && password[i+1] == password[i+2] && password[i+2] == password[i+3])
                {
                    return true;
                }
            }
            return false;
        }
        static bool NumbersInASeq(string password)
        {
            //checks make a char array with all the chars in the string password, convert from char array to int array and changes letters to -2
            char[] arr = password.ToArray();
            int[] ints = new int[arr.Length];
            int count = 0;
            
            foreach (char ch in arr)
            {
                if (char.IsDigit(ch))
                {
                    ints[count] = arr[count];
                }
                else
                {
                    ints[count] = -2;
                }
                count++;
            }

            //checks if there's a point where number are in a acending order in a row, returns true if there is
            for (int i = 0; i < ints.Length - 3; i++)
            {
                if (ints[i] + 1 == ints[i + 1] && ints[i + 1] + 1 == ints[i + 2] && ints[i + 2] + 1 == ints[i + 3])
                {
                    return true;
                }
            }
            return false;
        }


    }
}