using System.IO;
using System.Xml.Serialization;

namespace Assets.Scripts.Serialization
{
    public class DataSerializer
    {
        private static DataSerializer instance;

        public static DataSerializer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataSerializer();
                }
                return instance;
            }
            set { instance = value; }
        }

        public void Save<T>(string FileName, T value) where T : class
        {
            Serialize(File.OpenWrite(FileName), value);
        }

        public T Load<T>(string FileName) where T : class
        {
            return DeSerialize<T>(File.OpenRead(FileName));
        }
        
        public void Serialize<T>(Stream writer, T value) where T : class
        {
            var serializer = new XmlSerializer(value.GetType());
            serializer.Serialize(writer, value);
            writer.Flush();
        }

        public T DeSerialize<T>(Stream stream) where T : class
        {
            var serializer = new XmlSerializer(typeof (T));
            return serializer.Deserialize(stream) as T;
        }
    }
}