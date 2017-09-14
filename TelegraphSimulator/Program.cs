using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MorseCode; 
using ActOnFile; 

// Tasks
// use Dictionary - completed!
// improve interface - completed!

namespace MorseCode
{

    static class MorseTrans
    {

        static char[] symbols = new char[] {            'А', 'Б', 'В', 'Г',
                                                        'Д', 'Е', 'Ж', 'З',
                                                        'И', 'Й', 'К', 'Л',
                                                        'М', 'Н', 'О', 'П',
                                                        'Р', 'С', 'Т', 'У',
                                                        'Ф', 'Х', 'Ц',
                                                        'Ч', 'Ш', 'Щ',
                                                        'Ы', 'Ь', 'Э',
                                                        'Ю', 'Я', '1',
                                                        '2', '3', '4',
                                                        '5', '6', '7',
                                                        '8', '9', '0',
                                                        '.', ',', '!', '?', '\'', '\"', ';', ':', '-',
                                                        '+', '=', '_', '/', '(', ')', '&', '$', '@',
                                                        ' '};

        static string[] codeMorse = new string[] {
                                                        "*-", "-***", "*--", "--*",
                                                        "-**", "*", "***-", "--**",
                                                        "**", "*---", "-*-", "*-**",
                                                        "--", "-*", "---", "*--*",
                                                        "*-*", "***", "-", "**-",
                                                        "**-*", "****", "-*-*",
                                                        "---*", "----", "--*-",
                                                        "-*--", "-**-", "**-**",
                                                        "**--", "*-*-", "*----",
                                                        "**---", "***--", "****-",
                                                        "*****", "-****", "--***",
                                                        "---**", "----*", "-----",
                                                        "******", "*-*-*-", "-*-*--", "**--**", "*----*", "*-**-*", "-*-*-*", "---***", "-****-",
                                                        "*-*-*", "-***-", "**--*-", "-**-*", "-*--*", "-*--*-", "*-***", "***-**-", "*--*-*",
                                                        "space"};



        static Dictionary<string, char> DMorseRus = new Dictionary<string, char>(symbols.Length);   
        // key - "*-", value 'A'



        static MorseTrans() // Constructor
        {
            // making Dictionary
            ///////////////////////////
            makeDictionary();
            ///////////////////////////
        }



        public static string transToText(string str)
        {

            string final = "";
            int countCodes = 1;


            // counting codes
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' && str[i + 1] == ' ') countCodes++;
                else if (str[i] == ' ' && str[i + 1] != ' ') countCodes++;
            }
      


            string[] codes = new string[countCodes]; // countCodes - count of words and spaces



            // forming codes string
            int iter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' && str[i + 1] == ' ') // making spaces in main sentence
                {
                    iter++;
                    codes[iter] += "space";
                    iter++; i += 2;
                }
                else if (str[i] == ' ' && str[i + 1] != ' ') { iter++; continue; }

                codes[iter] += str[i];
            }



            // translating
            for (int i = 0; i < countCodes; i++)
            {

                final += DMorseRus[codes[i]];

            }


            return final;
        }





        private static void makeDictionary()
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                DMorseRus.Add(codeMorse[i], symbols[i]);
            }
        }

    

    }
  
}




namespace ActOnFile
{

    static class File
    {

        public static string[] readInnerFile()
        {
            string[] strings = { };



            try
            {
                strings = System.IO.File.ReadAllLines(@"text.txt");
            }
            catch (System.IO.FileNotFoundException exc)
            {
                Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Обращение к файлу завершено.");
                Console.WriteLine();
            }



            return strings;
        }


    }

}





namespace TelegraphSimulator
{

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Симулятор телеграфа.");
            Console.WriteLine();

            try
            {
                string[] fileStrings = File.readInnerFile();

                // translating strings from file              
                for (int i = 0; i < fileStrings.Length; i++)
                {
                    Console.WriteLine(MorseTrans.transToText(fileStrings[i]));
                }
            }
            catch (NullReferenceException obj)
            {
                Console.WriteLine("Error: был возвращён пустой объект. " + obj.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Работа программы завершена.");
            }



            Console.ReadKey();
        }
    }

}







/*- * **** -* --- *-** --- --* ** **  *-* *- --** *-* *- -*** --- - -*- **  *--* *-* --- --* *-* *- -- -- -* --- --* ---  --- -*** * *** *--* * ---* * -* ** *-*-  -***-  - *-* *--* ---*/
