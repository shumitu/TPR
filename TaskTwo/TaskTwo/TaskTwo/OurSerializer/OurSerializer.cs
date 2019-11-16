using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TaskTwo.OurSerializer
{
    public static class OurSerializer
    {
        public static void Serialize(string filename, object objectToSerialize)
        {
            if (objectToSerialize == null)
            {
                throw new ArgumentNullException("Object cannot be null");
            }

            Stream stream = null;
            try
            {
                stream = File.Open(filename, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, objectToSerialize);
            }

            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }


        public static T Deserialize<T>(string filename)
        {
            T objectToSerialize = default(T);
            Stream stream = null;

            try
            {
                stream = File.Open(filename, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (T)bFormatter.Deserialize(stream);
            }

            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return objectToSerialize;
        }
    }
}