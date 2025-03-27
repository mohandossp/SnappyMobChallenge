using System.Text;

namespace ChallengeA
{
    public class ChallangeA
    {
        public interface IPrintableObjects
        {
            string GetValue();
        }

        public class AlphabeticalStrings : IPrintableObjects
        {
            private static readonly Random _instanceRandom = new Random();
            private string _result;
            public AlphabeticalStrings()
            {
                _result = string.Empty;
            }
            public string GetValue()
            {
                var ContentLength = _instanceRandom.Next(10, 20);
                StringBuilder stringContent = new StringBuilder();
                for (int i = 0; i < ContentLength; i++)
                {
                    stringContent.Append((char)_instanceRandom.Next('a', 'z' + 1));
                }
                _result = stringContent.ToString();
                return _result;
            }
        }

        public class RealNumbers : IPrintableObjects
        {
            private static readonly Random _instanceRandom = new Random();
            public RealNumbers()
            {

            }
            public string GetValue()
            {
                return _instanceRandom.NextDouble().ToString("F2");
            }
        }
        public class Integers : IPrintableObjects
        {
            private static readonly Random _instanceRandom = new Random();
            public Integers()
            {

            }
            public string GetValue()
            {
                return _instanceRandom.Next(1, 1000).ToString();
            }
        }
        public class AlphaNumerics : IPrintableObjects
        {
            private static readonly Random _instanceRandom = new Random();
            private int MaxEmptySpaceCount = 10;

            public AlphaNumerics()
            {
                MaxEmptySpaceCount = 10;
            }

            public AlphaNumerics(int _MaxEmptySpaceCount)
            {
                MaxEmptySpaceCount = _MaxEmptySpaceCount;
            }
            public string GetValue()
            {
                var length = _instanceRandom.Next(10, 20);
                StringBuilder sb = new StringBuilder();
                for (var i = 0; i < length; i++)
                {
                    if (_instanceRandom.Next(0, 3) == 0)
                    {
                        sb.Append((char)_instanceRandom.Next('a', 'z' + 1));
                    }
                    else
                    {
                        sb.Append((char)_instanceRandom.Next('0', '9' + 1));
                    }
                }

                var EmptySpaceCountFirst = _instanceRandom.Next(0, MaxEmptySpaceCount + 1);
                var EmptySpaceCountLast = MaxEmptySpaceCount - EmptySpaceCountFirst;

                var result = String.Concat(new string(' ', EmptySpaceCountFirst),
                                            sb.ToString(),
                                            new string(' ', EmptySpaceCountLast));

                return result;

            }
        }

        public class PrintableObjects
        {
            private readonly IEnumerable<IPrintableObjects> ListprintableObjects;

            public PrintableObjects()
            {
                ListprintableObjects = new IPrintableObjects[]
                {
                new AlphabeticalStrings(),
                new RealNumbers(),
                new Integers(),
                new AlphaNumerics()
                };
            }
            public PrintableObjects(int MaxSpaceCount)
            {
                ListprintableObjects = new IPrintableObjects[]
                {
                new AlphabeticalStrings(),
                new RealNumbers(),
                new Integers(),
                new AlphaNumerics(MaxSpaceCount)
                };
            }
            public void Print(string FilePath, long MaxSize)
            {
                var FileSize = 0;
                var MaxFileSize = BytesToMB(MaxSize);
                var SbFileConent = new StringBuilder();
                var _InstanceRandom = new Random();


                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }

                if (!File.Exists(FilePath))
                {
                    using (File.Create(FilePath))
                    {

                    }
                }

                using (var sw = new StreamWriter(FilePath))
                {
                    while (FileSize < MaxFileSize)
                    {
                        var Index = _InstanceRandom.Next(0, ListprintableObjects.Count());
                        var PrintObject = ListprintableObjects.ElementAt(Index);

                        var PrintObjectResult = PrintObject.GetValue();
                        SbFileConent.Append(PrintObjectResult + ",");

                        FileSize += Encoding.UTF8.GetByteCount(PrintObjectResult + ",");
                        if (FileSize >= MaxFileSize)
                        {
                            break;
                        }
                    }

                    sw.Write(SbFileConent.ToString().TrimEnd(','));
                }
            }

            private long BytesToMB(long bytes)
            {
                return bytes * 1024 * 1024;
            }
        }
    }
}
