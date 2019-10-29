using System.Collections.Generic;
using Task_1.Part_1;

namespace Task_1.Part_4
{
    public interface IDataRepository
    {
        void AddRegister(Register person);
        Register GetRegister(int personId);
        IEnumerable<Register> GetAllRegisters();
        void DeleteRegister(int id);
        void AddToCatalog(Catalog catalog);
        Catalog GetFromCatalog(int id);
        IEnumerable<Catalog> GetAllFromCatalog();
        void DeleteFromCatalog(int id);
        void AddEvent(Event event1);
        Event GetEvent(int id);
        IEnumerable<Event> GetAllEvents();
        void DeleteEvent(int _id);
        void AddStatusDescription(StatusDescription description);
        StatusDescription GetStatusDescription(int id);
        IEnumerable<StatusDescription> GetAllStatusDescriptions();
        void DeleteStatusDescription(int id);
        }
}