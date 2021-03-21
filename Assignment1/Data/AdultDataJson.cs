using System.Collections.Generic;
using System.Linq;
using FileData;
using Models;

namespace Assignment1.Data
{
    public class AdultDataJson : IAdultData
    {
        private IList<Adult> adults;
        FileContext fileContext = new FileContext();

        public AdultDataJson()
        {
            adults = new List<Adult>(fileContext.Adults);
        }

        public IList<Adult> GetAdults()
        {
            List<Adult> temp = new List<Adult>(adults);
            return temp;
        }

        public Adult GetAdultById(int Id)
        {
            Adult temp = adults.First(a=>a.Id == Id);
            return temp;
        }

        public void AddAdult(Adult adult)
        {
            int max = adults.Max(x => x.Id);
            adult.Id = ++max;
            adults.Add(adult);
            fileContext.Adults.Add(adult);
            WriteAdultsToFile();
        }

        public void RemoveAdult(int adultId)
        {
            Adult adultToRemove = adults.First(a => a.Id == adultId);
            adults.Remove(adultToRemove);
            fileContext.Adults.Remove(adultToRemove);
            WriteAdultsToFile();
        }

        public void EditAdult(Adult adult)
        {
            Adult toEdit = adults.First(a => a.Id == adult.Id);
            toEdit.FirstName = adult.FirstName;
            toEdit.LastName = adult.LastName;
            toEdit.Age = adult.Age;
            toEdit.Height = adult.Height;
            toEdit.Weight = adult.Weight;
            toEdit.Sex = adult.Sex;
            toEdit.EyeColor = adult.EyeColor;
            toEdit.HairColor = adult.HairColor;
            toEdit.JobTitle.JobTitle = adult.JobTitle.JobTitle;
            toEdit.JobTitle.Salary = adult.JobTitle.Salary;
            fileContext.SaveChanges();
        }

        public void WriteAdultsToFile()
        {
            fileContext.SaveChanges();
        }
    }
}