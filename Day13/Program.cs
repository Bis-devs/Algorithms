using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\"Izberite del 1 ali 2 za dan 13:  ");
        string izbira = Console.ReadLine();

        if (izbira == "1")
        {
            Part1();
        }
        else if (izbira == "2")
        {
            Part2();
        }
        else
        {
            Console.WriteLine("Neveljavna izbira.");
        }
    }

    static void Part1()
    {
        string[] vrstice = File.ReadAllLines("./day13.txt");
        int vsotaPravilnih = 0;

        for (int i = 0; i < vrstice.Length; i += 3) // se premika za 3 vrstice: 2 z podatke + 1 prazna 
        {
            object LeftElement = ParseNestedList(vrstice[i]);
            object RightElement = ParseNestedList(vrstice[i + 1]);

            // se uporablja metoda CompareValues za primerjava elementa in če je left manjši kot desni vrne -1 (poglej podrobno različne scenarije v metodo)
            // če vrne -1 potem se doda redna številka obravnavenaga para v vsoti
            if (CompareValues(LeftElement, RightElement) == -1)
            {
                vsotaPravilnih += (i + 3) / 3;  //na pr. za par st.1 se obrvanava vrstica 0 , (0+3)/3=1 , za st.2 3+3/3=2...
            }
        }

        Console.WriteLine($"Vsota pravilnih parov je: {vsotaPravilnih}");
    }

    static void Part2()
    {
        string[] vrstice = File.ReadAllLines("./day13.txt");
        List<object> packets = new List<object>();

        // Parse the input lines, ignoring blank lines
        for (int i = 0; i < vrstice.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(vrstice[i]))
            {
                packets.Add(ParseNestedList(vrstice[i]));
            }
        }

        // Tukaj dodamo tiste nove
        object divider1 = ParseNestedList("[[2]]");
        object divider2 = ParseNestedList("[[6]]");
        packets.Add(divider1);
        packets.Add(divider2);

        packets.Sort(CompareValues);

        int index1 = packets.IndexOf(divider1) + 1; //shranimo index prvega, se začne od 0 zarad tega +1
        int index2 = packets.IndexOf(divider2) + 1;
        int result = index1 * index2;

        Console.WriteLine($"Rezultat za Part 2 je: {result}");
    }

    // Method to parse a string into a nested list structure
    static object ParseNestedList(string vrstica)
    {
        Stack<List<object>> stack = new Stack<List<object>>();
        List<object> trenutniSeznam = new List<object>();
        stack.Push(trenutniSeznam);
        int i = 0;

        while (i < vrstica.Length)
        {
            char c = vrstica[i];  //iteriranje po vsak znak v vrstici
            if (c == '[')
            {
                List<object> novSeznam = new List<object>();
                stack.Peek().Add(novSeznam); // pogleda kaj je na vrhu seznama, to je trenutniSeznam in vanjo ustvari nov seznam
                stack.Push(novSeznam); //zdaj novSeznam je trenutni seznam v katerem se dodajajo elemente
            }
            else if (c == ']')  // konec trenutne seznama
            {
                stack.Pop();
            }
            else if (Char.IsDigit(c))
            {
                int start = i;
                while (i < vrstica.Length && Char.IsDigit(vrstica[i])) //povečujemo i če je znak številka , samo pozitivne, saj nimamo negativne v input, če bi bile pa tudi - bi mogle ignorirati
                {
                    i++;
                }
                string numberStr = vrstica.Substring(start, i - start);
                stack.Peek().Add(int.Parse(numberStr));
                i--;
            }
            i++;
        }

        return trenutniSeznam.Count == 1 ? trenutniSeznam[0] : trenutniSeznam;
    }


    static int CompareValues(object left, object right)
    {

        // če imamo 2 integera
        if (left is int leftInt && right is int rightInt)
        {
            return leftInt.CompareTo(rightInt);
        }


        // če levega (left) je integer , se ustvari nov seznam z en element in sicer element left , enako velja tud za desnega
        if (left is int) left = new List<object> { left };
        if (right is int) right = new List<object> { right };


        // če sta oba elementa seznama
        if (left is List<object> leftList && right is List<object> rightList)
        {
            int minLength = Math.Min(leftList.Count, rightList.Count);
            for (int i = 0; i < minLength; i++)
            {
                int result = CompareValues(leftList[i], rightList[i]);
                if (result != 0) return result;
            }

            return leftList.Count.CompareTo(rightList.Count);

            //This compares the two counts and returns:
            // -1 if leftList.Count is less than rightList.Count(meaning the leftList runs out of elements first).
            //0 if both lists have the same number of elements.
            //1 if leftList.Count is greater than rightList.Count(meaning the rightList runs out of elements first).
        }

        throw new InvalidOperationException("Nepodprta primerjava podatkov.");
    }
}
