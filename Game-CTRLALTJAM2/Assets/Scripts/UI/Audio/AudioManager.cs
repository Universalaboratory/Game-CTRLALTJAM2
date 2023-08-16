using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Audio
{
    public class AudioManager : MonoBehaviour
    {
        private List<EventInstance> eventInstances;

        private EventInstance musicEventInstance;

        [Range(0f, 1f)] public float masterVolume = 1f;
        [Range(0f, 1f)] public float musicVolume = 1f;
        [Range(0f, 1f)] public float sfxVolume = 1f;

        public Bus masterBus;
        public Bus musicBus;
        public Bus menuSfxBus;

        public static GameObject _options;
        [SerializeField] private Slider _masterSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _sfxSlider;
        [SerializeField] private Button _backButton;

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

            masterBus = RuntimeManager.GetBus("bus:/");
            musicBus = RuntimeManager.GetBus("bus:/Music");
            menuSfxBus = RuntimeManager.GetBus("bus:/Sfx");

            _options = GameObject.FindGameObjectWithTag("Canvas Options");
            _options.SetActive(false);
        }

        private void Start()
        {
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(_options);

            currentState = GameStates.Intro;
            lastState = GameStates.Intro;

            InitializeMusic(FMODEvents.instance.introMusic);
        }

        private void Update()
        {
            masterBus.setVolume(masterVolume);
            musicBus.setVolume(musicVolume);
            menuSfxBus.setVolume(sfxVolume);

            _musicSlider.value = musicVolume;
            _sfxSlider.value = sfxVolume;
            _masterSlider.value = masterVolume;

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuStartScene") ||
                SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CreditScene"))
                currentState = GameStates.Menu;
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene"))
                currentState = GameStates.Game;

            if (currentState != lastState)
                ChooseMusic();
            else
                return;
        }

        public void OnMasterSliderValueChanged() { masterVolume = _masterSlider.value; }
        public void OnMusicSliderValueChanged() { musicVolume = _musicSlider.value; }

        public void OnMenuSFXSliderValueChanged() { sfxVolume = _sfxSlider.value; }

        private void ChooseMusic()
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuStartScene") ||
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

        public void Back()
        {
            PlayOneShot(FMODEvents.instance.menuConfirm, _backButton.transform.position);
            _options.SetActive(false);
        }
    }
}