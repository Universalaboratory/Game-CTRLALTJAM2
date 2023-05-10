using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Utilities;
using TMPro;

namespace UI.GameManagement
{
    public class UIMenuPause : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject gameOverMenu;
        [SerializeField] private GameObject HUDPanel;

        [Header("Texts")]
        [SerializeField] private TMP_Text _waveText;
        [SerializeField] private float _waveTextFadeTimer = 2.5f; 
        
        void Start()
        {
            Time.timeScale = 1;
            HUDPanel.SetActive(true);
            menuPanel.SetActive(false);
            gameOverMenu.SetActive(false);
            pauseButton.SetActive(true);
        }

        private void OnEnable()
        {
            GameplayEvents.OnNextWave += SetUpWaveText;
            GameplayEvents.OnGameOver += GameOverPanel;
        }

        private void OnDisable()
        {
            GameplayEvents.OnNextWave -= SetUpWaveText;
            GameplayEvents.OnGameOver -= GameOverPanel;            
        }

        public void ClickPauseButton()
        {           
            UtilityEvents.GamePause();

            menuPanel.SetActive(true);
            pauseButton.SetActive(false);
            HUDPanel.SetActive(false);
        }

        public void ClickPlayButton()
        {
            UtilityEvents.GameResume();

            menuPanel.SetActive(false);
            pauseButton.SetActive(true);
            HUDPanel.SetActive(true);
        }

        public void ClickRestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ClickExitButton()
        {
            SceneManager.LoadScene(Constants.MENU_START_SCENE);
        }
            
        private void GameOverPanel()
        {
            pauseButton.SetActive(false);
            menuPanel.SetActive(false);
            HUDPanel.SetActive(false);
            gameOverMenu.SetActive(true);
        }

        private void SetUpWaveText(WaveState currentWave)
        {
            var waveNumber = (int)currentWave;

            _waveText.gameObject.SetActive(true);
            _waveText.text = "WAVE " + waveNumber;
            StartCoroutine(FadeWaveText());
        }

        private IEnumerator FadeWaveText()
        {
            // pode fazer um fade melhor
            // usando While e o alpha

            yield return new WaitForSeconds(_waveTextFadeTimer);
            _waveText.gameObject.SetActive(false);
        }
    }
}