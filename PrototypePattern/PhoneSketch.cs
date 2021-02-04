using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PrototypePattern
{
    [Serializable]
    public class OperationSystem
    {
        public OperationSystem(string name, int version)
        {
            (this.Name, this.Version) = (name, version);
        }

        public OperationSystem(OperationSystem os)
        {
            (this.Name, this.Version) = (os.Name, os.Version);
        }

        public string Name { get; set; }
        public int Version { get; set; }
    }

    [Serializable]
    public class PhoneSketch : ICloneable
    {
        public PhoneSketch(string modelName, string hardware, OperationSystem operationSystem)
        {
            (this.ModelName, this.Hardware, this.OS) = (modelName, hardware, operationSystem);
        }

        public PhoneSketch(PhoneSketch duplicatemodel)
        {
            (this.ModelName, this.Hardware, this.OS) = (duplicatemodel.ModelName, duplicatemodel.Hardware, new OperationSystem(duplicatemodel.OS));
        }

        public string ModelName { get; set; }

        public string Hardware { get; set; }

        public OperationSystem OS { get; set; }

        public void Dump()
        {
            Console.WriteLine("\n{0, 20} {1, -10}", "Name: ", this.ModelName);
            Console.WriteLine("{0, 20} {1,-10}", "Hardware: ", this.Hardware);
            Console.WriteLine("{0, 20} {1,-10}", "OS name: ", this.OS.Name);
            Console.WriteLine("{0, 20} {1,-10}", "OS version: ", this.OS.Version);
        }

        public object DeepCopy()
        {
            object o = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                o = binFormatter.Deserialize(tempStream);
            }
            return o;
        }

        public object Clone()
        {
            //return new PhoneSketch(this.ModelName, this.Hardware, new OperationSystem(this.OS));
            return new PhoneSketch(this);
        }
    }    
}
