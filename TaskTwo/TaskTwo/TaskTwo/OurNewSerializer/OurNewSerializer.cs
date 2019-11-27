using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace TaskTwo.OurNewSerializer
{
    public class OurNewSerializer : Formatter
    {
        public override ISurrogateSelector SurrogateSelector { get; set; }
        public sealed override SerializationBinder Binder { get; set; }
        public sealed override StreamingContext Context { get; set; }

        private string DataRow { get; set; }
        private List<string> DataToSave { get; }
        private List<string> DeserializeInfo { get; }
        private Dictionary<string, object> References { get; }


        public OurNewSerializer()
        {
            Binder = new OurBinder();
            Context = new StreamingContext(StreamingContextStates.File);
            DataRow = "";
            DataToSave = new List<string>();
            DeserializeInfo = new List<string>();
            References = new Dictionary<string, object>();
    }

        public override void Serialize(Stream serializationStream, object desiredObjToSerialize)
        {
            if (desiredObjToSerialize is ISerializable data)
            {
                SerializationInfo infoAboutObject = new SerializationInfo(desiredObjToSerialize.GetType(), new FormatterConverter());
                Binder.BindToName(desiredObjToSerialize.GetType(), out string assemblyName, out string typeName);

                DataRow += assemblyName + ";"
                                        + typeName + ";"
                                        + m_idGenerator.GetId(desiredObjToSerialize, out bool firstTime);

                data.GetObjectData(infoAboutObject, Context);

                foreach (SerializationEntry singleObjItem in infoAboutObject)
                {
                    WriteMember(singleObjItem.Name, singleObjItem.Value);
                }

                DataToSave.Add(DataRow + "\n");
                DataRow = "";

                while (m_objectQueue.Count != 0)
                {
                    Serialize(null, m_objectQueue.Dequeue());
                }

                // Saving to stream...

                if (serializationStream != null)
                {
                    using (StreamWriter writer = new StreamWriter(serializationStream))
                    {
                        foreach (string line in DataToSave)
                        {
                            writer.Write(line);
                        }
                    }
                }

            }
            else
            {
                throw new ArgumentException("Chosen desiredObjToSerialize is not Iserializable");
            }
        }


        public override object Deserialize(Stream serializationStream)
        {
            if (serializationStream != null)
            {
                using (StreamReader reader = new StreamReader(serializationStream))
                {
                    String line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        DeserializeInfo.Add(line);
                    }
                }

                foreach (string item in DeserializeInfo)
                {
                    String[] splits = item.Split(';');
                    References.Add(splits[2], FormatterServices.GetSafeUninitializedObject(Binder.BindToType(splits[0], splits[1])));
                }
            }

            foreach (string singleDataRow in DeserializeInfo)
            {
                string[] dividedDataRow = singleDataRow.Split(';');
                Type typeOfDeserializedObj = Binder.BindToType(dividedDataRow[0], dividedDataRow[1]);

                if (typeOfDeserializedObj != null)
                {
                    SerializationInfo info = new SerializationInfo(typeOfDeserializedObj, new FormatterConverter());
                    GetInfoFromDeserializedInfoRow(info, dividedDataRow);
                    Type[] arrayOfConstructorTypes = { info.GetType(), Context.GetType() };
                    object[] arrayOfConstructorParams = { info, Context };
                    References[dividedDataRow[2]]
                        .GetType()
                        .GetConstructor(arrayOfConstructorTypes)
                        ?.Invoke(References[dividedDataRow[2]],
                            arrayOfConstructorParams);
                }

            }
            return References["1"];
        }


        #region WriteRegion


        protected override void WriteDateTime(DateTime value, string name)
        {
            DataRow +=
                ";" + value.GetType()
                    + "=" + name
                    + "=" + value.ToUniversalTime().ToString();
        }


        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType == typeof(String))
            {
                WriteString(obj, name);
            }
            else
            {
                WriteObject(obj, name, memberType);
            }
        }


        protected void WriteString(object obj, string name)
        {
            DataRow += ";" + obj.GetType() + "=" + name + "=" + "\"" + (String)obj + "\"";
        }


        protected void WriteObject(object obj, string name, Type type)
        {
            if (obj != null)
            {
                DataRow += ";" + obj.GetType() + "=" + name + "=" + m_idGenerator.GetId(obj, out bool firstTime).ToString();
                if (firstTime)
                {
                    m_objectQueue.Enqueue(obj);
                }
            }
            else
            {
                DataRow += ";" + "null" + "=" + name + "=-1";
            }
        }


        protected override void WriteSingle(float value, string name)
        {
            DataRow += ";" + value.GetType() + "=" + name + "=" + value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
        }


        #endregion


        #region notImplemented

        protected override void WriteBoolean(bool value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteByte(byte value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteChar(char value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteSByte(sbyte value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteTimeSpan(TimeSpan value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteUInt16(ushort value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteUInt32(uint value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteUInt64(ulong value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }


        protected override void WriteDecimal(decimal value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteDouble(double value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteInt16(short value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteInt32(int value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteInt64(long value, string name)
        {
            throw new NotImplementedException();
        }


        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region private

        private void GetInfoFromDeserializedInfoRow(SerializationInfo info, string[] splitedDeserializationInfoRow)
        {
            for (int i = 3; i < splitedDeserializationInfoRow.Length; i++)
            {
                string[] data = splitedDeserializationInfoRow[i].Split('=');
                Type typeToSave = Binder.BindToType(splitedDeserializationInfoRow[0], data[0]);

                if (typeToSave == null)
                {
                    if (!data[0].Equals("null"))
                    {
                        SaveValueToSerializedInformation(info, Type.GetType(data[0]), data[1], data[2]);
                    }
                    else
                    {
                        info.AddValue(data[1], null);
                    }
                }
                else
                {
                    if (!data[2].Equals("-1"))
                    {
                        info.AddValue(data[1], References[data[2]], typeToSave);
                    }
                }
            }
        }


        private void SaveValueToSerializedInformation(SerializationInfo info, Type type, string name, string val)
        {
            switch (type.ToString())
            {
                case "System.Single":
                    info.AddValue(name, Single.Parse(val, System.Globalization.CultureInfo.InvariantCulture));
                    break;
                case "System.DateTime":
                    info.AddValue(name, DateTime.Parse(val, System.Globalization.CultureInfo.InvariantCulture));
                    break;
                case "System.String":
                    info.AddValue(name, val);
                    break;
            }
        }


        #endregion
    }
}