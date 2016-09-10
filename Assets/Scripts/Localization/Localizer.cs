using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Models;
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
            if (string.IsNullOrEmpty(key))
                return "";

            if (!Instance.locals.ContainsKey(Instance.CurrentCulture) ||
                !Instance.locals[Instance.CurrentCulture].ContainsKey(key))
            {
                Instance.AddLocalization(key);
                return string.Format("[{0}][{1}]", Instance.CurrentCulture, key);
            }

            return Instance.locals[Instance.CurrentCulture][key];
        }

        private void AddLocalization(string key)
        {
            string folder = Path.Combine(Application.streamingAssetsPath, "Local");
            string filePath = Path.Combine(folder, CurrentCulture + ".local");
            using (var file = File.Open(filePath, FileMode.Create, FileAccess.Write))
            {
                using (var sw = new StreamWriter(file))
                {
                    locals[CurrentCulture].Add(key, key);
                    foreach (var k in locals[CurrentCulture].Keys.OrderBy(k => k))
                    {
                        sw.WriteLine("{0}={1}", k, locals[CurrentCulture][k]);
                    }
                }
            }
        }

        public void EnsureAllLocalKeyExist(List<Card> cards)
        {
            var keys = new List<string>();
            foreach (var card in cards)
            {
                keys.Add(card.Name);
                keys.Add(card.DescriptionTextLocalCode);
                keys.Add(card.LeftOptionTextLocalCode);
                keys.Add(card.RightOptionTextLocalCode);
            }

            keys = keys.Distinct().ToList();
            foreach (var key in keys.ToList())
            {
                if (locals[CurrentCulture].ContainsKey(key))
                {
                    keys.Remove(key);
                }
            }

            foreach (var key in keys)
            {
                locals[CurrentCulture].Add(key, key);
            }

            string folder = Path.Combine(Application.streamingAssetsPath, "Local");
            string filePath = Path.Combine(folder, CurrentCulture + ".local");
            using (var file = File.Open(filePath, FileMode.Create, FileAccess.Write))
            {
                using (var sw = new StreamWriter(file))
                {
                    foreach (var k in locals[CurrentCulture].Keys.OrderBy(k => k))
                    {
                        sw.WriteLine("{0}={1}", k, locals[CurrentCulture][k]);
                    }
                }
            }
        }

        public void Load(string folderPath)
        {
            locals = new Dictionary<string, Dictionary<string, string>>();
            CurrentCulture = "en_US";

            foreach (var file in Directory.GetFiles(folderPath, "*.local"))
            {
                LoadFile(file);
            }
        }

        private void LoadFile(string file)
        {
            string culture = new FileInfo(file).Name.Replace(".local", string.Empty);

            if (locals.ContainsKey(culture))
            {
                locals.Remove(culture);
            }

            locals.Add(culture, new Dictionary<string, string>());
            var local = locals[culture];

            var rows = File.ReadAllLines(file);
            foreach (var row in rows)
            {
                var args = row.Split(new[] {'='}, 2);
                local.Add(args[0], args[1]);
            }
        }
    }
}