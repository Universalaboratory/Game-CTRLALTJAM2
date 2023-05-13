using UnityEngine;
using FMODUnity;
using UnityEngine.SceneManagement;

namespace UI.Audio
{
    public class FMODEvents : MonoBehaviour
    {
        public static FMODEvents instance { get; private set; }

        [field: Header("Game musics")]
        [field: SerializeField] public EventReference menuMusic { get; private set; }
        [field: SerializeField] public EventReference gameplayMusic { get; private set; }
        [field: SerializeField] public EventReference bossMusic { get; private set; }

        //[field: Header("SFX")]

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("FMOD Events already exists!");
            }
            else
                instance = this;
        }
    }
}