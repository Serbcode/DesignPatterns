using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PrototypePattern
{
    [Serializable]
    public record OperationSystem(string Name, int Version)
    {
        public OperationSystem(OperationSystem os)
        {
            (Name, Version) = (os.Name, os.Version);
        }
    }

    [Serializable]
    public record PhoneSketch
    {
        public PhoneSketch(string modelName, string hardware, OperationSystem operationSystem)
        {
            (ModelName, Hardware, OS) = (modelName, hardware, operationSystem);
        }

        public PhoneSketch(PhoneSketch duplicate)
        {
            (ModelName, Hardware, OS) =
                (duplicate.ModelName, duplicate.Hardware, new OperationSystem(duplicate.OS));
        }

        public string ModelName { get; set; }

        public string Hardware { get; set; }

        public OperationSystem OS { get; set; }

        public override string ToString()
        {
            return $"\n{"Name:",20} {ModelName,-10}\n{"Hardware:",20} {Hardware,-10}\n{"OS name:",20} {OS.Name,-10}\n{"OS version:",20} {OS.Version,-10}";
        }


        public object DeepCopy()
        {
            return this with { };
        }

        // public object DeepCopy()
        // {
        //     object o = null;
        //     using (MemoryStream tempStream = new MemoryStream())
        //     {
        //         BinaryFormatter binFormatter = new BinaryFormatter(null,
        //             new StreamingContext(StreamingContextStates.Clone));

        //         binFormatter.Serialize(tempStream, this);
        //         tempStream.Seek(0, SeekOrigin.Begin);

        //         o = binFormatter.Deserialize(tempStream);
        //     }
        //     return o;
        // }

        public object CloneIt()
        {
            //return new PhoneSketch(this.ModelName, this.Hardware, new OperationSystem(this.OS));
            return new PhoneSketch(this);
        }
    }
}
