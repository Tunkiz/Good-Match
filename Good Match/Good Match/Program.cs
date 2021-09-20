
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Good_Match
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Choose one option:\n 1. Use direct inputs\n 2. Use CSV file inputs\n");
            int dInput = Int16.Parse(Console.ReadLine());
            
            if (dInput == 1)
            {
                Console.WriteLine("Enter names");
                String fname = Console.ReadLine();
                String sname = Console.ReadLine();
                UserInputRes(fname, sname);
            }
            else if (dInput == 2)
            {
                ReadCsv();
            }
            
            else {
                Console.WriteLine("Invalid input");
            }
            Console.ReadLine();

        }

/*
 Run the good match program for every entry in the first set against every entry in
the second set and print the results in a textfile called output.txt 
*/
        static void ReadCsv() {
            String[] line = File.ReadAllLines("input.csv");
            var gender = new List<String>();
            var names = new List<String>();
            var maleSet = new List<String>();
            var femaleSet = new List<String>();
            Regex reg = new Regex("[^A-Za-z]");
            for (int i = 0; i < line.Length; i++)
            {
                String[] rowdata = line[i].Split(',');
                names.Add(rowdata[0]);
                gender.Add(rowdata[1].ToLower().ToString());
            }
            for (int i = 0; i < gender.Count; i++)
            {
                if (gender[i].Trim().Equals("m"))
                {
                    if (!maleSet.Contains(names[i].Trim()))
                    {
                        maleSet.Add(names[i]);
                    }

                }
                else
                {
                    if (!femaleSet.Contains(names[i]))
                    {
                        femaleSet.Add(names[i]);
                    }

                }
            }

            String My_sentance = "";
            List<String> resultList = new List<string>();
            List<int> numbers = new List<int>();
           
            
            for (int i = 0; i < maleSet.Count; i++)
                {
                    for (int k = 0; k < femaleSet.Count; k++)
                    {
                    if ((reg.IsMatch(maleSet[i]) || reg.IsMatch(femaleSet[k])))
                    {
                        Console.WriteLine(maleSet[i]+" or "+femaleSet[k]+" contains unsupported characters");
                    }
                    else
                    {

                        My_sentance = maleSet[i] + " matches " + femaleSet[k];
                        My_sentance = My_sentance.Replace(" ", string.Empty).ToLower().Trim();
                        String countArr = "";

                        while (My_sentance.Length > 0)
                        {

                            int count = 0;
                            for (int j = 0; j < My_sentance.Length; j++)
                            {
                                if (My_sentance[0] == My_sentance[j])
                                {
                                    count++;
                                }
                            }
                            countArr += count;
                            My_sentance = My_sentance.Replace(My_sentance[0].ToString(), string.Empty);
                        }

                        String arr = RecursiveAdd(countArr);
                        int result = Int16.Parse(arr);


                        if (result >= 80)
                        {
                            resultList.Add(maleSet[i] + " matches " + femaleSet[k] + " " + result + "%" + ", " + "good match");
                            numbers.Add(result);
                        }
                        else
                        {
                            resultList.Add(maleSet[i] + " matches " + femaleSet[k] + " " + result + "%");
                            numbers.Add(result);
                        }

                    }
                    }
               
                }
            
            Mysort mysort = new Mysort();
            Mysort.sort(resultList, numbers);
            
        }

        static void Sort() { }
       
        static void UserInputRes(String fname, String sname)
        {
            Regex reg = new Regex("[^A-Za-z]");
            if (reg.IsMatch(fname) || reg.IsMatch(sname))
            {
                Console.WriteLine("The names contains unsupported characters");
            }
            else
            {
                String My_sentance = "";
                ArrayList resultList = new ArrayList();
                My_sentance = fname + " matches " + sname;
                My_sentance = My_sentance.Replace(" ", string.Empty).ToLower().Trim();
                String countArr = "";

                while (My_sentance.Length > 0)
                {

                    int count = 0;
                    for (int j = 0; j < My_sentance.Length; j++)
                    {
                        if (My_sentance[0] == My_sentance[j])
                        {
                            count++;
                        }
                    }
                    countArr += count;
                    My_sentance = My_sentance.Replace(My_sentance[0].ToString(), string.Empty);
                }

                String arr = RecursiveAdd(countArr);
                int result = Int16.Parse(arr);


                if (result >= 80)
                {
                    resultList.Add(fname + " matches " + sname + " " + result + "%" + ", " + "good match");
                }
                else
                {
                    resultList.Add(fname + " matches " + sname + " " + result + "%");
                }

                Console.Write(resultList[0]);
            }
        }

        /*
- Add the left most and right most number that has not been added yet and put its sum at
   the end of the result.
- If there is only one number left add that number to the end of the result
- Repeat this process until there are only 2 digits left in the final string
*/
        static String RecursiveAdd(String countArr)
        {
            String arr = "";
            while (countArr.Length > 1)
            {
                int total = Int16.Parse(countArr[0].ToString()) + Int16.Parse(countArr[countArr.Length - 1].ToString());
                countArr = countArr.Remove(0, 1);
                countArr = countArr.Remove(countArr.Length - 1);
                arr += total;
                if (countArr.Length == 1)
                {
                    arr += countArr[0];
                }

            }

            if (arr.Length > 2)
            {
                countArr = arr;
                return RecursiveAdd(countArr);
            }
            return arr;
        }
    }
}





            
            