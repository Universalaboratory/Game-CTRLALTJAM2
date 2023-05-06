using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace UI.GameManagement
{
    public class UIMenuManager : MonoBehaviour
    {
        public void ClickStartButton()
        {
            SceneManager.LoadScene(Constants.GAME_SCENE_1);
        }

        public void ClickOptionsButton()
        {
            SceneManager.LoadScene(Constants.OPTIONS_SCENE);
        }

        public void ClickCreditButton()
        {
            SceneManager.LoadScene(Constants.CREDIT_SCENE);
        }

        public void ClickQuitButton()
        {

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
                Application.Quit();
        }

        public void ClickBackButton()
        {
            SceneManager.LoadScene(Constants.MENU_START_SCENE);
        }
    }
}