using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Xml;

namespace Assignment_linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>()
        {
            new Person("Bill", "Smith", 41),
            new Person("Sarah", "Jones", 22),
            new Person("Stacy","Baker", 21),
            new Person("Vivianne","Dexter", 19 ),
            new Person("Bob","Smith", 49 ),
            new Person("Brett","Baker", 51 ),
            new Person("Mark","Parker", 19),
            new Person("Alice","Thompson", 18),
            new Person("Evelyn","Thompson", 58 ),
            new Person("Mort","Martin", 58),
            new Person("Eugene","deLauter", 84 ),
            new Person("Gail","Dawson", 19 ),

        };

            Console.WriteLine("-------------------");
            //1 write linq statement for people with last name that starts with the letter D

            var result1 = from obj in people
                          where obj.LastName.StartsWith("D")
                          select obj;
            foreach (var person in result1)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("-------------------");
            //2 write a linq statement for people with last names that starts with the letter D and displays the count.	

            var result2 = (from obj in people
                           where obj.LastName.StartsWith("D")
                           select obj).Count();

            Console.WriteLine(result2);
            Console.WriteLine("-------------------");
            //3 Write linq statement for first Person Older Than 40 In Descending Alphabetical Order By First Name

            var result3 = from obj in people
                          where obj.Age > 40
                          orderby obj.FirstName descending
                          select obj;
            foreach (var person in result3)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("-------------------");
            //4 write linq statement for people’s full name(concat firstname and last name)
            var result4 = from obj in people
                          select new { Full_Name = obj.FirstName + "" + obj.LastName };
            foreach (var person in result4)
            {
                Console.WriteLine(person.Full_Name);
            }
            Console.WriteLine("-------------------");
            //5 Write a query that returns most frequent character in string. Assume that there is only one such character.
            string l = "hello";
            var m = l.GroupBy(c => c).OrderByDescending(c => c.Count()).First().Key;
            Console.WriteLine(m);
            Console.WriteLine("-------------------");


            //Find out Unique values Given a non - empty list of strings, return a list that contains only unique(non - duplicate) strings.
            //Expected input and output
            //["abc", "xyz", "klm", "xyz", "abc", "abc", "rst"] → ["klm", "rst"]
            List<string> result5 = new List<string>() { "abc", "xyz", "klm", "xyz", "abc", "abc", "rst" };
            var result = (from obj1 in result5

                          group obj1 by obj1 into grp
                          select new { cnt = grp.Count(), key = grp.Key });

            foreach (var item in result)//linq query execution
            {
                if (item.cnt == 1)
                    Console.WriteLine(item.key);
            }
            Console.WriteLine("-------------------");
            //3.	Top 5 number Write a query that returns top 5 numbers from the list of integers in descending order.Expected input and output
            //[78, -9, 0, 23, 54, 21, 7, 86]  → 86 78 54 23 21
            List<int> num = new List<int>() { 78, -9, 0, 23, 54, 21, 7, 86 };
            var result_3 =(from obj2 in num
                           orderby obj2 descending
                           select obj2).Take(5);
            foreach (var item in result_3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------");
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };
            var li = from obj3 in fruits
                     where obj3.StartsWith("L")
                     select obj3;
            foreach (var item in li)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------");
            // Which of the following numbers are multiples of 4 or 6
            List<int> mixedNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            var mul=from obj4 in mixedNumbers
                    where obj4%4==0 || obj4%6==0
                   select obj4;

            foreach (var item in mul)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------");

            // Output how many numbers are in this list
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            var t = (from obj6 in numbers
                     select obj6).Count();
            
            
            Console.WriteLine(t);
            Console.WriteLine("-------------------");
            // How much money have we made?
            List<double> purchases = new List<double>()
          {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            var Money = (from money in purchases
                        select money).Sum();
            Console.WriteLine(Money);
            Console.WriteLine("-------------------");

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };
            var high = (from Prices in prices
                        select Prices).Max();
            Console.WriteLine(high);
            Console.WriteLine("-------------------");
            //Given the same customer set, display how many millionaires per bank
            var customers = new List<Customer>() {
                new Customer("Bob Lesman", 80345.66, "FTB"),
                new Customer("Joe Landy", 9284756.21, "WF"),
                new Customer("Meg Ford", 487233.01, "BOA"),
                new Customer("Peg Vale", 7001449.92, "BOA"),
                new Customer("Mike Johnson", 790872.12, "WF"),
                new Customer( "Les Paul", 8374892.54, "WF"),
                new Customer( "Sid Crosby", 957436.39, "FTB"),
                new Customer("Sarah Ng", 56562389.85, "FTB"),
                new Customer("Tina Fey", 1000000.00, "CITI"),
                new Customer("Sid Brown", 49582.68, "CITI")
            };
            var Bank = (from data in customers
                       where data.Balance >= 1000000
                       group data by data.Bank into grp
                       select new { cnt = grp.Count(), key = grp.Key });
            foreach(var item in Bank)
            {
                Console.WriteLine(item.key+" "+item.cnt );
            }
            Console.WriteLine("-------------------");
            //Display Top 3 customers per bank.

            var bank2 = from data2 in customers
                        group data2.Balance by data2.Bank into grp
                    
                        select new {max=grp.Max(),key=grp.Key};
           
           
                foreach(var i in bank2)
                {
                Console.WriteLine(i);

                }
            


        }







    } }
