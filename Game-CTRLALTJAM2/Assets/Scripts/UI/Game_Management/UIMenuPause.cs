using UnityEngine;

namespace UI.GameManagement
{
    public class UIMenuPause : MonoBehaviour
    {
        public GameObject menuPanel;
        public GameObject pauseButton;

        void Start()
        {
            Time.timeScale = 1;
            menuPanel.SetActive(false);
            pauseButton.SetActive(true);
        }

        public void ClickPauseButton()
        {           
            UtilityEvents.GamePause();

            menuPanel.SetActive(true);
            pauseButton.SetActive(false);
        }

        public void ClickPlayButton()
        {
            UtilityEvents.GameResume();

            menuPanel.SetActive(false);
            pauseButton.SetActive(true);
        }
    }
}