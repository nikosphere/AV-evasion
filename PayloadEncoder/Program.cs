using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PayloadEncoder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //XOR
            Console.WriteLine("Input your key in hex format (eg. AA) for XOR encoding: ");
            string inputkey = Console.ReadLine();
            if (!byte.TryParse(inputkey, System.Globalization.NumberStyles.HexNumber, null, out byte XORkey))
            {
                Console.WriteLine("try again");
                return;
            }


            Console.WriteLine("Enter the full filepath containing your payload in format 'C:\\path\\to\\file.txt' : ");
            string filename = Console.ReadLine();
            string filecontent = File.ReadAllText(filename);
            MatchCollection bytecontent = Regex.Matches(filecontent, @"0x[0-9A-Fa-f]{2}");

            List<byte> bytes = new List<byte>();

            foreach (Match match in bytecontent)
            {
                string hexString = match.Value.Replace("0x", "");
                byte b = Convert.ToByte(hexString, 16);
                bytes.Add(b);
            }

            byte[] encoded = new byte[bytes.Count];

            for (int i = 0; i < bytes.Count; i++)
            {
                encoded[i] = (byte)(bytes[i] ^ XORkey);
            }

            Console.WriteLine("byte[] buf = new byte [" + encoded.Length +"] {");
            for (int i = 0; i < encoded.Length; i++)
            {
                Console.Write("0x" + encoded[i].ToString("X2"));
                if (i != encoded.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" };");
        } 
           

            //Caesar

            //ROT13

            //Base64

            //AES256
        }
    }

