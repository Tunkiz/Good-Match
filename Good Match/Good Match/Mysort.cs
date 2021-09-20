using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Good_Match
{
    class Mysort
    {
        public class myComparer : IComparer
        {
            int IComparer.Compare(Object xx, Object yy)
            {
                Vals x = (Vals)xx;
                Vals y = (Vals)yy;
                return x.Num.CompareTo(y.Num);
            }
        }

        public static void sort( List<string> resultList, List<int> num) {

            ArrayList myList = new ArrayList();
            for (int i = 0; i < resultList.Count; i++)
            {
                myList.Add(new Vals(resultList[i], num[i]));

            }
            
            myList.Sort(new myComparer());
            ArrayList myLi = new ArrayList();
            foreach (Vals item in myList)
            {
                myLi.Add(item.Name);
            }
            // create a writer and open the file
            TextWriter output = new StreamWriter("output.txt");
            for (int i = myList.Count - 1; i >= 0; i--)
            {
                // write a line of text to the file
                
                output.WriteLine(myLi[i]);
                Console.WriteLine(myLi[i]);
            }

            
            output.Close();

        } 

    }
}
class Vals
{
    string name;
    int num;
    public Vals(string name, int num)
    {
        Name = name;
        Num = num;
    }
    public string Name { get => name; set => name = value; }
    public int Num { get => num; set => num = value; }
}