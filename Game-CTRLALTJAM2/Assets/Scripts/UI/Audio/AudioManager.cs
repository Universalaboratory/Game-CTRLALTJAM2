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

        [Range(0f, 1f)] public float musicVolume = 1f;
        [Range(0f, 1f)] public float sfxVolume = 1f;
        
        public Bus musicBus;
        public Bus sfxBus;

        public static AudioManager instance { get; private set; }

        private enum GameStates
        {
            Intro,
            Menu,
            Game
        };

        private GameStates currentState, lastState;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Audio Manager already exists!");
            }
            else
                instance = this;

            eventInstances = new List<EventInstance>();

            musicBus = RuntimeManager.GetBus("bus:/Music");
            sfxBus = RuntimeManager.GetBus("bus:/Sfx");
        }

        private void Start()
        {
            DontDestroyOnLoad(this);

            currentState = GameStates.Intro;
            lastState = GameStates.Intro;

            InitializeMusic(FMODEvents.instance.introMusic);
        }

        private void Update()
        {
            musicBus.setVolume(musicVolume);
            sfxBus.setVolume(sfxVolume);

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuStartScene") ||
                    SceneManager.GetActiveScene() == SceneManager.GetSceneByName("OptionsScene") ||
                    SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CreditScene"))
                currentState = GameStates.Menu;
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene"))
                currentState = GameStates.Game;

            if (currentState != lastState)
                ChooseMusic();
            else
                return;
        }

        private void ChooseMusic()
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuStartScene") ||
                    SceneManager.GetActiveScene() == SceneManager.GetSceneByName("OptionsScene") ||
                    SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CreditScene"))
            {
                CleanUp();
                InitializeMusic(FMODEvents.instance.menuMusic);
                lastState = GameStates.Menu;
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene"))
            {
                CleanUp();
                InitializeMusic(FMODEvents.instance.gameplayMusic);
                lastState = GameStates.Game;
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
        }

        public void CleanUp()
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