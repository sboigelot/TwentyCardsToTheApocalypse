using System;
using System.IO;
using System.Xml.Serialization;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Effects;
using UnityEngine;

namespace Assets.Scripts.Serialization
{
    public class DataSerializer : Singleton<DataSerializer>
    {
        public void Save<T>(string fileName, T value) where T : class
        {
            Debug.Log("Saving file: " + fileName);
            using (var fileStream = File.Open(fileName, FileMode.CreateNew, FileAccess.ReadWrite))
            {
                Serialize(fileStream, value);
                //fileStream.Close();
            }
        }

        public T LoadFromStreamingAssets<T>(string folder, string fileName) where T : class
        {
            string dataPath = Path.Combine(Application.streamingAssetsPath, folder);
            string filePath = Path.Combine(dataPath, fileName);
            return Load<T>(filePath);
        }

        public T LoadFromAppData<T>(string folder, string fileName) where T : class
        {
            string dataPath = Application.persistentDataPath;
            string filePath = Path.Combine(dataPath, fileName);
            if (!File.Exists(filePath))
            {
                return null;
            }

            return Load<T>(filePath);
        }

        public void SaveToAppData<T>(string folder, string fileName, T data) where T : class
        {
            string dataPath = Application.persistentDataPath;
            string filePath = Path.Combine(dataPath, fileName);
            Save(filePath, data);
        }

        public T Load<T>(string fileName) where T : class
        {
            Debug.Log("Loading file: " + fileName);
            using (var fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                var data = DeSerialize<T>(fileStream);
                //fileStream.Close();
                return data;
            }
        }

        public void Serialize<T>(Stream writer, T value) where T : class
        {
            var extraTypes = GetExtraTypes();
            var serializer = new XmlSerializer(value.GetType(), extraTypes);
            serializer.Serialize(writer, value);
            writer.Flush();
        }

        public T DeSerialize<T>(Stream stream) where T : class
        {
            var extraTypes = GetExtraTypes();
            var serializer = new XmlSerializer(typeof(T), extraTypes);
            return serializer.Deserialize(stream) as T;
        }

        private Type[] GetExtraTypes()
        {
            return new[]
            {
                typeof(CardEffect),
                typeof(CardEffectType),
                typeof(Apocalypse),
                typeof(Card),
                typeof(Deck),
                typeof(PlayerProfile),
                typeof(World),
                typeof(WorldImprovement),
                typeof(WorldStat),
            };
        }
    }
}