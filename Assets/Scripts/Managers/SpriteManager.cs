using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SpriteManager : Singleton<SpriteManager>
    {
        private Dictionary<string, Sprite> sprites;
        
        private Sprite notFoundSprite;

        public SpriteManager()
        {
            if (notFoundSprite == null)
            {
                // Generate a 32x32 magenta image
                var notFoundTexture2D = new Texture2D(32, 32, TextureFormat.ARGB32, false);
                Color32[] pixels = notFoundTexture2D.GetPixels32();
                for (int i = 0; i < pixels.Length; i++)
                {
                    pixels[i] = new Color32(255, 0, 255, 255);
                }

                notFoundTexture2D.SetPixels32(pixels);
                notFoundTexture2D.Apply();
                notFoundSprite = Sprite.Create(notFoundTexture2D, new Rect(0, 0, notFoundTexture2D.width, notFoundTexture2D.height), new Vector2(0.5f, 0.5f), 32);
            }

            sprites = new Dictionary<string, Sprite>();
            string folderPath = Path.Combine(Application.streamingAssetsPath, "Images");
            LoadSpritesFromDirectory(folderPath);
        }
        
        public static Sprite Get(string key)
        {
            if (!Instance.sprites.ContainsKey(key))
            {
                return Instance.notFoundSprite;
            }

            return Instance.sprites[key];
        }

        private void LoadSpritesFromDirectory(string folderPath)
        {
            string[] subDirs = Directory.GetDirectories(folderPath);
            foreach (string sd in subDirs)
            {
                LoadSpritesFromDirectory(sd);
            }

            string[] files = Directory.GetFiles(folderPath);
            foreach (string filePath in files)
            {
                var fileInfo = new FileInfo(filePath);
                if (fileInfo.Extension.ToLower() == ".jpg" || fileInfo.Extension.ToLower() == ".png")
                {
                    LoadImage(filePath);
                }
            }
        }

        private void LoadImage(string filePath)
        {
            byte[] imageBytes = File.ReadAllBytes(filePath);

            Texture2D imageTexture = new Texture2D(2, 2);

            // LoadImage will correctly resize the texture based on the image file
            if (imageTexture.LoadImage(imageBytes))
            {
                imageTexture.filterMode = FilterMode.Point;
                string spriteName = Path.GetFileNameWithoutExtension(filePath);
                Sprite s = Sprite.Create(imageTexture, new Rect(0, 0, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f), 32);
                sprites[spriteName] = s;
            }
        }
    }
}
