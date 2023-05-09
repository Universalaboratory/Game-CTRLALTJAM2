using UnityEngine;

namespace UI.GameManagement
{
    public class UIMenuPause : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject gameOverMenu;
        


        void Start()
        {
            Time.timeScale = 1;
            menuPanel.SetActive(false);
            gameOverMenu.SetActive(false);
            pauseButton.SetActive(true);
        }

        private void OnEnable()
        {
            GameplayEvents.OnGameOver += GameOverPanel;
        }

        private void OnDisable()
        {
            GameplayEvents.OnGameOver -= GameOverPanel;            
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

        private void GameOverPanel()
        {
            pauseButton.SetActive(false);
            menuPanel.SetActive(false);
            gameOverMenu.SetActive(true);
        }
    }
}