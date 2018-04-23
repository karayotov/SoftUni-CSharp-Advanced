using System;
using System.Linq;
using System.Collections.Generic;

namespace P04_HitList
{
    class StartUp
    {
        private const string endTransmission = "end transmissions";
        private const string nameSeparator = "=";
        private const string pairSeparator = ";";
        private const string keyAndValueSeparator = ":";
        private const string killGuySeparator = " ";
        private const string proceedMessage = "Proceed";
        private const string needMoreInfoMessage = "Need {0} more info.";


        private static int targetInfoIndex;
        private static string inputLine;
        private static string name;
        private static string[] pairs;
        private static Dictionary<string, Dictionary<string, string>> collection;
        private static int infoIndex;

        static void Main(string[] args)
        {
            //•	“{name}={key}:{value};{key}:{value};…”.
            GetTargetInfoIndex();

            collection = new Dictionary<string, Dictionary<string, string>>();

            while ((inputLine = Console.ReadLine()) != endTransmission)
            {
                ExtractName();

                AddNewNameToDictionary();

                ExtractPair();

                AddPairToDictionary();
            }

            KillNamedGuy(Console.ReadLine());

            CompareIndexes();

            
        }

        private static void CompareIndexes()
        {
            if (targetInfoIndex > infoIndex)
            {
                Console.WriteLine(string.Format(needMoreInfoMessage, targetInfoIndex - infoIndex));
            }
            else
            {
                Console.WriteLine(proceedMessage);
            }
        }

        private static void KillNamedGuy(string killThisName)
        {
            killThisName = SplitString(killThisName, killGuySeparator)[1];

            Console.WriteLine($"Info on {killThisName}:");

            collection[killThisName].OrderBy(key => key.Key).ToList().ForEach(pair => Console.WriteLine($"---{pair.Key}: {pair.Value}"));

            infoIndex = collection[killThisName].Sum(pair => pair.Key.Length + pair.Value.Length);

            Console.WriteLine($"Info index: {infoIndex}");

        }

        private static void AddNewNameToDictionary()
        {
            if (collection.ContainsKey(name) == false)
            {
                collection.Add(name, new Dictionary<string, string>());
            }
        }

        private static void AddPairToDictionary()
        {
            string[] pairArr;

            string key, value;

            foreach (var pair in pairs)
            {
                pairArr = SplitString(pair, keyAndValueSeparator);

                key = pairArr[0];

                value = pairArr[1];

                collection[name][key] = value;

            }
        }

        private static void ExtractPair()
        {
            pairs = SplitString(inputLine, pairSeparator);
        }

        private static void ExtractName()
        {
            string[] data = SplitString(inputLine, nameSeparator);

            name = data[0];

            inputLine = data[1];
        }

        private static void GetTargetInfoIndex()
        {
            targetInfoIndex = int.Parse(Console.ReadLine());
        }

        private static string[] SplitString(string splitMe, string separator)
        {
            return splitMe.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}
