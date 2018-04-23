using System;
using System.Collections.Generic;
using System.Linq;

namespace p01_KeyRevolver
{
    public class StartUp
    {
        private const string bulletMatched = "Bang!";
        private const string bulletIsBiggerThanLocker = "Ping!";
        private const string runOutOfBullets = "Couldn't get through. Locks left: {0}";
        private const string safeWasOpened = "{0} bullets left. Earned ${1}";
        private const string reloading = "Reloading!";

        private static int priceOfEachBullet;
        private static int sizeOfGunBarrel;
        private static Stack<int> bullets;
        private static Queue<int> barrel;
        private static Queue<int> locks;
        private static int valueOfTheIntelligence;
        private static int earnedMoney;

        static void Main(string[] args)
        {


            ReadDataLines();
            StartShooting();


        }

        private static void StartShooting()
        {
            barrel = new Queue<int>();
            LoadBullets();

            while (true)
            {

                if (bullets.Count == 0 && barrel.Count == 0)
                {
                    PrintLine(string.Format(runOutOfBullets, locks.Count));
                    return;
                }

                Shoot();


                if (locks.Count == 0)
                {
                    PrintLine(string.Format(safeWasOpened, (bullets.Count + barrel.Count), earnedMoney));
                    return;
                }
            }
        }

        private static void LoadBullets()
        {
            for (int i = 0; i < sizeOfGunBarrel; i++)
            {
                if (bullets.Count != 0)
                    barrel.Enqueue(bullets.Pop());
            }
        }

        private static void Shoot()
        {
            int bullet = barrel.Dequeue();
            int safeLock = locks.Peek();

            earnedMoney -= priceOfEachBullet;

            if (bullet <= safeLock)
            {
                PrintLine(bulletMatched);
                locks.Dequeue();
            }
            else
            {
                PrintLine(bulletIsBiggerThanLocker);
            }

            if (barrel.Count == 0)
            {
                if (bullets.Count != 0)
                {
                    ReloadBullets();
                }
            }
        }

        private static void ReloadBullets()
        {
            LoadBullets();

            PrintLine(reloading);
        }

        private static void ReadDataLines()
        {
            priceOfEachBullet = ReadPriceOfEachBullet(Console.ReadLine());
            sizeOfGunBarrel = ReadSizeOfGunBarrel(Console.ReadLine());
            bullets = ReadBullets(Console.ReadLine());
            locks = ReadLocks(Console.ReadLine());
            valueOfTheIntelligence = ReadValueOfTheIntelligence(Console.ReadLine());

            earnedMoney = valueOfTheIntelligence;
        }

        private static int ReadValueOfTheIntelligence(string stringLine)
        {
            return int.Parse(stringLine);
        }

        private static Queue<int> ReadLocks(string stringLine)
        {
            string[] array = StringToIntArray(stringLine);
            Queue<int> bullets = new Queue<int>();

            foreach (var bulletStr in array)
            {
                int bullet = int.Parse(bulletStr);

                bullets.Enqueue(bullet);
            }

            return bullets;
        }

        private static Stack<int> ReadBullets(string stringLine)
        {
            string[] array = StringToIntArray(stringLine);

            Stack<int> bullets = new Stack<int>();

            foreach (var bulletStr in array)
            {
                int bullet = int.Parse(bulletStr);

                bullets.Push(bullet);
            }

            return bullets;
        }

        private static int ReadSizeOfGunBarrel(string stringLine)
        {
            return int.Parse(stringLine);
        }

        private static int ReadPriceOfEachBullet(string stringLine)
        {
            return int.Parse(stringLine);
        }

        private static string[] StringToIntArray(string stringLine)
        {
            return stringLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        private static void PrintLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
