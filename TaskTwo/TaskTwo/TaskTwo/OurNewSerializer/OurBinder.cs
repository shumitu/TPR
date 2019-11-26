using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace TaskTwo.OurNewSerializer
{
    public class OurBinder : SerializationBinder
    {
        public override Type BindToType(string assembly, string type)
        {
            Assembly asm = Assembly.Load(assembly);
            return asm.GetType(type);
        }


        public override void BindToName(Type serializedType, out string assembly, out string type)
        {
            Assembly asm = serializedType.Assembly;
            assembly = asm.FullName;
            type = serializedType.FullName;
        }
    }
}