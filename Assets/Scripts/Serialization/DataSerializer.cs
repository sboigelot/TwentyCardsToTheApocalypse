using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.Serialization
{
    public class DataSerializer : Singleton<DataSerializer>
    {
        public void Save<T>(string FileName, T value) where T : class
        {
            using (var fileStream = File.Open(FileName, FileMode.CreateNew, FileAccess.ReadWrite))
            {
                Serialize(fileStream, value);
                fileStream.Close();
            }
        }

        public T LoadFromStreamingAssets<T>(string folder, string fileName) where T : class, new()
        {
            string dataPath = Path.Combine(Application.streamingAssetsPath, folder);
            string filePath = Path.Combine(dataPath, fileName);
            return Load<T>(filePath);
        }

        public T Load<T>(string FileName) where T : class
        {
            using (var fileStream = File.Open(FileName, FileMode.Open, FileAccess.Read))
            {
                var data = DeSerialize<T>(fileStream);
                fileStream.Close();
                return data;
            }
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