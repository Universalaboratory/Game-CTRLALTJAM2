using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.GameManagement
{
    public class UIMenuManager : MonoBehaviour
    {

        public void ClickStartButton()
        {
            SceneManager.LoadScene(2);
        }

        public void ClickOptionsButton()
        {
            SceneManager.LoadScene(3);
        }

        public void ClickCreditButton()
        {
            SceneManager.LoadScene(4);
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
            SceneManager.LoadScene(1);
        }
    }
}


