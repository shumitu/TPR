using System.IO;
using Task_1.Part_1;

namespace TaskTwo.OurSerializer
{
    public interface IOurSerializer
    {
        void Serialize(DataContext dataContext, Stream outputStream);
        DataContext Deserialize(Stream inputStream);
    }
}