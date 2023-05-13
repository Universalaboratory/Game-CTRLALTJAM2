using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace UI.Audio
{
    public class AudioManager : MonoBehaviour
    {
        private List<EventInstance> eventInstances;

        private EventInstance musicEventInstance;

        private bool isPlaying;

        public float MusicVolume = 1;

        public static AudioManager instance { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Audio Manager already exists!");
            }
            else
                instance = this;

            eventInstances = new List<EventInstance>();
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            isPlaying = false;
        }

        private void Update()
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("IntroScene") || 
                SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuStartScene"))
            {
                if (!isPlaying)
                    InitializeMusic(FMODEvents.instance.menuMusic);
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene"))
            {
                CleanUp();

                if (!isPlaying)
                    InitializeMusic(FMODEvents.instance.gameplayMusic);
            }
        }

        public void PlayOneShot(EventReference sound, Vector3 worldPos)
        {
            RuntimeManager.PlayOneShot(sound, worldPos);
        }

        public EventInstance CreateInstance(EventReference eventReference)
        {
            EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
            eventInstances.Add(eventInstance);
            return eventInstance;
        }

        public void InitializeMusic(EventReference musicEventReference)
        {
            musicEventInstance = CreateInstance(musicEventReference);
            musicEventInstance.start();
            isPlaying = true;
        }

        public void CleanUp()
        {
            foreach (var eventInstance in eventInstances)
            {
                eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                eventInstance.release();
                isPlaying= false;
            }
        }

        private void OnDestroy()
        {
            CleanUp();
        }
    }
}