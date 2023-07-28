using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;
using UI.Audio;

namespace UI.GameManagement
{
    public class UIMenuManager : MonoBehaviour
    {
        private GameObject _menuButtons;
        [SerializeField] private GameObject _credits;

        public void ClickStartButton()
        {
            _menuButtons = GameObject.FindGameObjectWithTag("PlayGameButton");
            GameObject.FindAnyObjectByType<AudioManager>().PlayOneShot(FMODEvents.instance.menuPlay, _menuButtons.transform.position);
        
            SceneManager.LoadScene(Constants.GAME_SCENE_1);
        }

        public void ClickOptionsButton()
        {
            _menuButtons = GameObject.FindGameObjectWithTag("OptionsButton");
            GameObject.FindAnyObjectByType<AudioManager>().PlayOneShot(FMODEvents.instance.menuConfirm, _menuButtons.transform.position);
            AudioManager._options.SetActive(true);
        }

        public void ClickCreditButton()
        {
            _menuButtons = GameObject.FindGameObjectWithTag("CreditsButton");
            GameObject.FindAnyObjectByType<AudioManager>().PlayOneShot(FMODEvents.instance.menuConfirm, _menuButtons.transform.position);
            //SceneManager.LoadScene(Constants.CREDIT_SCENE);
            _credits.SetActive(true);
        }

        public void ClickQuitButton()
        {
            _menuButtons = GameObject.FindGameObjectWithTag("QuitButton");
            GameObject.FindAnyObjectByType<AudioManager>().PlayOneShot(FMODEvents.instance.menuConfirm, _menuButtons.transform.position);

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
                Application.Quit();
        }

        public void ClickBackButton()
        {
            _menuButtons = GameObject.FindGameObjectWithTag("BackButton");
            GameObject.FindAnyObjectByType<AudioManager>().PlayOneShot(FMODEvents.instance.menuConfirm, _menuButtons.transform.position);
            _credits.SetActive(false);
        }
    }
}