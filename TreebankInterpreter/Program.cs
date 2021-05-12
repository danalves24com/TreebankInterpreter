using System;
using System.Collections.Generic;
using System.IO;
namespace TreebankInterpreter
{
    class Program
    {

        public const string textStarter = "( (S", textEnder = "SU /";

        static void Main(string[] args)
        {
            bool isADirector = true; // path query
            string location = args[0];
            if (isADirector)
            {                

                if (File.Exists(location))
                {
                    Console.WriteLine("found dir");
                    String[] file = File.ReadAllLines(location);
                    bool inDataRow = false;
                    List<String> sentenceStack = new List<string>();
                    String currentSentence = "";
                    foreach(String lineO in file)
                    {
                        String line = lineO.Trim();
                        if(!inDataRow)
                        {
                            if (line.Contains(textStarter))
                            {
                                inDataRow = true;
                                currentSentence = line;
                            }
                        }
                        else
                        {
                            if(line.Contains(textEnder))
                            {
                                inDataRow = false;
                                currentSentence += line;
                                sentenceStack.Add(currentSentence);
                            }
                            else
                            {
                                currentSentence += line;
                            }
                        }
                        
                    }
                    foreach(String sentence in sentenceStack)
                    {
                        Console.WriteLine("$$");
                        Console.WriteLine(sentence);
                        Console.WriteLine("$$");
                    }

                }
                else
                {
                    Console.WriteLine("file not found");
                }

            }
        }
    }
}
