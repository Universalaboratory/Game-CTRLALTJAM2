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
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("IntroScene"))
            {
                Debug.LogWarning("Introduction Scene Recognized!");
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuStartScene"))
            {
                Debug.LogWarning("Menu Scene Recognized!");
                InitializeMusic(FMODEvents.instance.menuMusic);
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene"))
            {
                Debug.LogWarning("Game Scene Recognized!");
                InitializeMusic(FMODEvents.instance.menuMusic);
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

        private void InitializeMusic(EventReference musicEventReference)
        {
            musicEventInstance = CreateInstance(musicEventReference);
            musicEventInstance.start();
        }

        private void CleanUp()
        {
            foreach (var eventInstance in eventInstances)
            {
                eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                eventInstance.release();
            }
        }

        private void OnDestroy()
        {
            CleanUp();
        }
    }
}