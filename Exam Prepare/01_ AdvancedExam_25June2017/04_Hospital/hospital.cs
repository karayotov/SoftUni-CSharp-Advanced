using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Hospital
{
    class hospital
    {
        static void Main()
        {
            Dictionary<string, List<string>> departments = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "Output")
            {
                string[] inputData = input.Split();
                string department = inputData[0];
                string doctor = inputData[1] + " " + inputData[2];
                string patient = inputData[3];

                if (departments.ContainsKey(department) == false)
                {
                    departments.Add(department, new List<string>());
                }
                departments[department].Add(patient);

                if (doctors.ContainsKey(doctor) == false)
                {
                    doctors.Add(doctor, new List<string>());
                }
                doctors[doctor].Add(patient);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputData = input.Split();

                if (inputData.Length == 1)
                {
                    foreach (var patient in departments[input])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    int roomNumber = 0;
                    if (int.TryParse(inputData[1], out roomNumber))
                    {
                        int skip = 3 * (roomNumber - 1);

                        foreach (var patient in departments[inputData[0]].Skip(skip).Take(3).OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        foreach (var patient in doctors[input].OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
            }
        }
    }
}