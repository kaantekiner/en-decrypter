using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace endecrypter
{
    class EncrypterDecrypter
    {
        static string encryptedword = "";
        static List<string> List = new List<string>()
        {"1","2","3","4","5","6","7","8","9","0",
            "q","w","e","r","t","y","u","ı","o","p","ğ","ü","a","s","d","f","g","h","j","k","l","ş","i","z","x","c","v","b","n","m","ö","ç",
            "Q","W","E","R","T","Y","U","I","O","P","Ğ","Ü","A","S","D","F","G","H","J","K","L","Ş","İ","Z","X","C","V","B","N","M","Ö","Ç",
            "!","+","%","&","/","(",")","=","?","_","*","-",":",";","^"," "};
        static List<string> Encrypted = new List<string>();
        static List<string> EncryptWay = new List<string>();
        static List<string> All = new List<string>();
        static void Main()
        {
            Console.WriteLine("Encrypt or Decrypt?[e/d]");
            string process = Console.ReadLine();
            if (process == "e" || process == "d")
            {
                if (process == "e")
                {
                    Encrypt();
                }
                if (process == "d")
                {
                    Decrypt("n");
                }
                Console.WriteLine("\n");
                Console.WriteLine("Press a key to exit");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Wrong, please press enter to exit, and please start again.");
                Console.ReadLine();
                System.Environment.Exit(1);
            }
        }
        static private void Encrypt()
        {
            Console.Write("hi, enter the keyword for encrypt;" + "\n");
            string keyword = Console.ReadLine();
            Console.WriteLine("keyword to encrypt = " + keyword);
            Console.WriteLine("lenght = "+keyword.Length);
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int randomnumber = rnd.Next(1, 9);
                List.Insert(0, randomnumber.ToString());
            }
            for (int i = 0; i < keyword.Count(); i++)
            {
                int randomnumber = rnd.Next(10, List.Count());
                EncryptWay.Add(randomnumber.ToString());
                Encrypted.Add(List[randomnumber]);
            }
            Console.WriteLine("\n");
            Console.WriteLine("then some verbose;"+"\n");
            Console.WriteLine("EncryptWay = ");
            for (int i = 0; i < EncryptWay.Count(); i++)
            {
                Console.Write(EncryptWay[i]);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Encrypted = ");
            for (int i = 0; i < Encrypted.Count(); i++)
            {
                Console.Write(Encrypted[i]);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Places = ");
            for (int i = 0; i < Encrypted.Count(); i++)
            {
                Console.Write(List.IndexOf(keyword[i].ToString()));
            }
            Console.WriteLine("\n");
            string EncryptedPart = "";
            string Places = "";
            string TheWaystringBottom = "";
            string TheNumberMatters = (keyword.Count() + 10).ToString();
            for (int i = 0; i < Encrypted.Count(); i++)
            {
                EncryptedPart += Encrypted[i];
            }
            for (int i = 0; i < Encrypted.Count(); i++)
            {
                Places += List.IndexOf(keyword[i].ToString());
            }
            for (int i = 0; i < EncryptWay.Count(); i++)
            {
                TheWaystringBottom += EncryptWay[i];
            }
            encryptedword = EncryptedPart + Places + TheWaystringBottom + TheNumberMatters;
            Console.WriteLine("encrypted version = " + encryptedword);
            Console.WriteLine("\n");
            Console.WriteLine("Want to decrypt that now?[y/n]");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                Decrypt("y");
            }
            else
            {
                Decrypt("n");
            }
        }
        static private void Decrypt(string went)
        {
            List<int> intlist = new List<int>();
            string wordtodecrypt = "";
            if (went == "y")
            {
                wordtodecrypt = encryptedword;
                Console.WriteLine("\n"+"your encrypted word is = " + wordtodecrypt);
            }
            else
            {
                Console.WriteLine("please enter the encrypted keyword;");
                wordtodecrypt = Console.ReadLine();
            }
            char lastpart1;
            char lastpart2;
            char lastpart3;
            string lastpartall;
            if (wordtodecrypt.Length >= 453)
            {
                lastpart1 = wordtodecrypt[wordtodecrypt.Length - 1];
                lastpart2 = wordtodecrypt[wordtodecrypt.Length - 2];
                lastpart3 = wordtodecrypt[wordtodecrypt.Length - 3];
                lastpartall = lastpart3.ToString() + lastpart2.ToString() + lastpart1.ToString();
            }
            else
            {
                lastpart1 = wordtodecrypt[wordtodecrypt.Length - 1];
                lastpart2 = wordtodecrypt[wordtodecrypt.Length - 2];
                lastpartall = lastpart2.ToString() + lastpart1.ToString();
            }
            int lastpartallint = Int32.Parse(lastpartall);
            int reallengt = lastpartallint - 10;
            Console.WriteLine("real lenght of word= "+reallengt);
            string parttodecrypt = wordtodecrypt.Substring(reallengt, reallengt*2);
            Console.WriteLine("the part to decrypt = "+parttodecrypt);
            string decryptedpart = "";
            for (int i = 0; i < parttodecrypt.Length; i+=2)
            {
                string harf = parttodecrypt[i].ToString() + parttodecrypt[i + 1].ToString();
                intlist.Add(Int32.Parse(harf));
            }
            for (int i = 0; i < intlist.Count(); i++)
            {
                decryptedpart += List[intlist[i]];
            }
            Console.WriteLine("your decrypted-original word is = "+decryptedpart);
        }
    }
}