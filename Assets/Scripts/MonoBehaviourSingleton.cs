using UnityEngine;

namespace Assets.Scripts
{
    public class MonoBehaviourSingleton<T> : MonoBehaviour where T : class, new()
    {
        public MonoBehaviourSingleton()
        {
            Instance = this as T;
        }

        public static T Instance { get; set; }
    }
}