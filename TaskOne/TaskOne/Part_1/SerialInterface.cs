using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task_1.Part_1
{
    public interface SerialInterface
    {
        string Serialize(ObjectIDGenerator idGenerator);
        void Deserialize(string[] data, Dictionary<long, Object> deserializedObjects);
    }
}