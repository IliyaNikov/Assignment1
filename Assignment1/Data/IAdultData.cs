using System.Collections.Generic;
using Models;

namespace Assignment1.Data
{
    public interface IAdultData
    {
        IList<Adult> GetAdults();

        Adult GetAdultById(int Id);

        void AddAdult(Adult adult);

        void RemoveAdult(int adultId);

        void EditAdult(Adult adult);
    }
}