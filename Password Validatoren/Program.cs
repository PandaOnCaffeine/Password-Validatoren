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
            if (!MinMaxChar(password))
            {
                Console.WriteLine("Passwordet skal være på min 12 og max 64 tegn");
                Program.Gui();
            }
            else if (!UpperLower(password))
            {
                Console.WriteLine("Passwordet skal indeholde både store og små tegn");
                Program.Gui();
            }
            else if (!Number(password))
            {
                Console.WriteLine("Passwordet skal indeholde numre");
                Program.Gui();
            }
            else if (!SpecialChars(password))
            {
                Console.WriteLine("Passwordet skal indeholde et eller flere special tegn");
                Program.Gui();
            }
            else
            {
                if (true)
                {

                }
            }
        }

        static void Moddellayer()
        {
            password = Console.ReadLine();
        }

        static void Controller()
        {
            Program.Moddellayer();
            Program.MinMaxChar(password);
            Program.UpperLower(password);
            Program.Number(password);
            Program.SpecialChars(password);
        }
        static bool MinMaxChar(string password)
        {
            if (password.Length > 11)
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
            return password.Any(ch => !Char.IsLetterOrDigit(ch));
        }
        static bool Has4InARow(string password)
        {
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


            for (int i = 0; i < ints.Length-3; i++)
            {
                if (ints[i] == ints[i + 1]+1 && ints[i + 1] == ints[i + 2]+1 && ints[i + 2] == ints[i + 3]+1)
                {
                    return true;
                }
            }
            return false;
        }


    }
}