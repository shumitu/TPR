using System;
using System.Linq;
using Task_1.Part_1;

namespace Task_1.Part_2
{
    public class RandomDataFill : IDataFill
    {
        private int numberOfEntries;


        public RandomDataFill(int numberOfEntries)
        {
            this.numberOfEntries = numberOfEntries;
        }


        public void Fill(DataContext context)
        {
            Random rand = new Random();

            Catalog catalog;
            Register register;
            StatusDescription statusDesc;

            for(int i = 0; i < numberOfEntries; i++)
            {
                register = new Register(i, getRandomString(rand.Next(3, 10)), getRandomString(rand.Next(3, 10)));
                catalog = new Catalog(i, getRandomString(rand.Next(6, 12)), getRandomString(rand.Next(8, 12)), rand.Next(1900, 2020));
                statusDesc = new StatusDescription(catalog, rand.NextDouble() * 90 + 10, getRandomString(rand.Next(10, 20)), DateTime.Now);

                context.lists.Add(register);
                context.catalogs.Add(i, catalog);
                context.descriptions.Add(statusDesc);
            }
        }


        private string getRandomString(int randomStringLength)
        {
            Random rand = new Random();
            const string charSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(charSet, randomStringLength)
      .Select(s => s[rand.Next(s.Length)]).ToArray());

        }
    }
}