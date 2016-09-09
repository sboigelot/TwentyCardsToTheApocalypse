using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Localization
{
    public class Localizer : Singleton<Localizer>
    {
        private Dictionary<string, Dictionary<string, string>> locals;

        public Localizer()
        {
            Load(Path.Combine(Application.streamingAssetsPath, "Local"));
        }

        public string CurrentCulture { get; set; }

        public static string Get(string key)
        {
            if (!Instance.locals.ContainsKey(Instance.CurrentCulture) ||
                string.IsNullOrEmpty(key) ||
                !Instance.locals[Instance.CurrentCulture].ContainsKey(key))
            {
                return string.Format("[{0}][{1}]", Instance.CurrentCulture, key);
            }

            return Instance.locals[Instance.CurrentCulture][key];
        }

        public void Load(string folderPath)
        {
            locals = new Dictionary<string, Dictionary<string, string>>();
            CurrentCulture = "en_US";

            foreach (var file in Directory.GetFiles(folderPath, "*.local"))
            {
                string culture = new FileInfo(file).Name.Replace(".local", string.Empty);
                locals.Add(culture, new Dictionary<string, string>());
                var local = locals[culture];

                var rows = File.ReadAllLines(file);
                foreach (var row in rows)
                {
                    var args = row.Split(new[] { '=' }, 2);
                    local.Add(args[0], args[1]);
                }
            }
        }
    }
}