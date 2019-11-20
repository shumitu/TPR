using Task_1.Part_1;
using System.IO;

namespace TaskTwo.OurSerializer
{
    public interface ISerializer
    {
        void Serialize(DataContext dataContext, Stream outputStream);
        DataContext Deserialize(Stream inputStream);
    }
}