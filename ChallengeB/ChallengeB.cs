using ChallengeA;
using System.ComponentModel;

namespace ChallengeB
{
    internal class ChallengeB
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter Maximum Space Count to append before and after in AlphaNumberic.");
            //int MaxEmptySpacesNumber = int.Parse(Console.ReadLine());
            //if (MaxEmptySpacesNumber >= 0 && MaxEmptySpacesNumber <= 100)
            //    Console.WriteLine("Entered: " + MaxEmptySpacesNumber);
            //else
            //    Console.WriteLine("Entered Invalid Number. Enter number in between 0 to 100");

            Console.WriteLine("Challange A - Starts");
            int MaxEmptySpacesNumber = 10;
            int MaxFileSize = 10;
            string FileName = "/app/data/";
            var InputFileName = FileName + "input/PrintObjectsResultA_Input.txt";
            var PrintObjectA = new ChallangeA.PrintableObjects(MaxEmptySpacesNumber);
            PrintObjectA.Print(InputFileName, MaxFileSize);
            Console.WriteLine("Challenge A File Saved successfully");
            Console.WriteLine("Challange A - End");


            Console.WriteLine("Challange B - Starts");
            var PrintObjectB = new ChallangeB.PrintableObjects();
            PrintObjectB.Print(InputFileName);

            var OutPutFileName = FileName + "output/PrintObjectsResultB_Output.txt";
            PrintObjectB.Write(InputFileName, OutPutFileName);
            Console.WriteLine("Challenge B File Saved successfully");
            Console.WriteLine("Challange B - End");
        }
    }

    internal class ChallangeB
    {
        private enum PrintTypes
        {
            [Description("Alphabetical Strings")]
            AlphaCharacters,
            [Description("Integers")]
            Integers,
            [Description("Real Numbers")]
            RealNumbers,
            [Description("AlphaNumerics")]
            Alphanumerics
        }
        public class PrintableObjects
        {
            public void Print(string FilePath)
            {
                var FileContent = File.ReadAllText(FilePath);
                var PrintContent = FileContent.Split(',');

                foreach (var str in PrintContent)
                {
                    string value = str.Trim();
                    if (IsAlphaCharacters(value))
                    {
                        Console.WriteLine($"Print Object: {value}, Type: {PrintTypes.AlphaCharacters.ToString()}");
                        continue;
                    }
                    else if (IsIntegers(value))
                    {
                        Console.WriteLine($"Print Object: {value}, Type: {PrintTypes.Integers.ToString()}");
                        continue;
                    }
                    else if (IsRealNumbers(value))
                    {
                        Console.WriteLine($"Print Object: {value}, Type: {PrintTypes.RealNumbers.ToString()}");
                        continue;
                    }
                    else if (IsAlphaNumerics(value))
                    {
                        Console.WriteLine($"Print Object: {value}, Type: {PrintTypes.Alphanumerics.ToString()}");
                        continue;
                    }
                }
            }
            public void Write(string FilePath, string OutputFilePath)
            {
                var FileContent = File.ReadAllText(FilePath);
                var PrintContent = FileContent.Split(',');

                if (File.Exists(OutputFilePath))
                {
                    File.Delete(OutputFilePath);
                }

                if (!File.Exists(OutputFilePath))
                {
                    using (File.Create(OutputFilePath))
                    {

                    }
                }

                using (StreamWriter Write = new StreamWriter(OutputFilePath, true))
                {
                    foreach (var str in PrintContent)
                    {
                        string value = str.Trim();
                        if (IsAlphaCharacters(value))
                        {
                            Write.WriteLine($"Print Object: {value}, Type: {PrintTypes.AlphaCharacters.ToString()}");
                            continue;
                        }
                        else if (IsIntegers(value))
                        {
                            Write.WriteLine($"Print Object: {value}, Type: {PrintTypes.Integers.ToString()}");
                            continue;
                        }
                        else if (IsRealNumbers(value))
                        {
                            Write.WriteLine($"Print Object: {value}, Type: {PrintTypes.RealNumbers.ToString()}");
                            continue;
                        }
                        else if (IsAlphaNumerics(value))
                        {
                            Write.WriteLine($"Print Object: {value}, Type: {PrintTypes.Alphanumerics.ToString()}");
                            continue;
                        }
                    }
                }

            }
            private bool IsAlphaCharacters(string str)
            {
                return !string.IsNullOrEmpty(str) && str.All(char.IsLetter);
            }
            private bool IsIntegers(string str)
            {
                return !string.IsNullOrEmpty(str) && str.All(char.IsDigit);
            }
            private bool IsRealNumbers(string str)
            {
                bool result = false;
                if (Double.TryParse(str, out double res))
                {
                    result = str.Contains(".");
                }
                return result;
            }
            private bool IsAlphaNumerics(string str)
            {
                return !string.IsNullOrEmpty(str) && str.All(char.IsLetterOrDigit) && str.Any(char.IsLetter) && str.Any(char.IsDigit);
            }
        }
    }
}
