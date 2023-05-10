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
        [SerializeField] private GameObject _gameplayPanel;
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _winPanel;


        [Header("Texts")]
        [SerializeField] private TMP_Text _waveText;
        [SerializeField] private float _waveTextFadeTimer = 2.5f;
        private Color _waveTextColor;

        void Start()
        {
            Time.timeScale = 1;
            CloseAllPanel();
            _gameplayPanel.SetActive(true);

            _waveTextColor = _waveText.color;
        }

        private void OnEnable()
        {
            GameplayEvents.OnNextWave += SetUpWaveText;
            GameplayEvents.OnBoss += SetUpBossText;
            GameplayEvents.OnGameOver += GameOverPanel;
            GameplayEvents.OnWinGame += WinPanel;
        }

        private void OnDisable()
        {
            GameplayEvents.OnNextWave -= SetUpWaveText;
            GameplayEvents.OnBoss -= SetUpBossText;
            GameplayEvents.OnGameOver -= GameOverPanel;
            GameplayEvents.OnWinGame -= WinPanel;
        }

        private void CloseAllPanel()
        {
            _gameplayPanel.SetActive(false);
            _menuPanel.SetActive(false);
            _gameOverPanel.SetActive(false);
        }

        public void ClickPauseButton()
        {
            UtilityEvents.GamePause();

            CloseAllPanel();
            _menuPanel.SetActive(true);
        }

        public void ClickPlayButton()
        {
            UtilityEvents.GameResume();

            CloseAllPanel();
            _gameplayPanel.SetActive(true);
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
            CloseAllPanel();
            _gameOverPanel.SetActive(true);
        }

        private void WinPanel()
        {
            CloseAllPanel();
            _winPanel.SetActive(true);

        }

        private void SetUpWaveText(WaveState currentWave)
        {
            var waveNumber = (int)currentWave;

            _waveText.gameObject.SetActive(true);
            _waveText.text = "WAVE " + waveNumber;
            StartCoroutine(FadeWaveText());
            
        }
        
        private void SetUpBossText()
        {
            _waveText.gameObject.SetActive(true);
            _waveText.text = "BOSS TIME";
            StartCoroutine(FadeWaveText());
        }

        private IEnumerator FadeWaveText()
        {
            var _alpha = _waveText.color.a;

            yield return new WaitForSeconds(2f);

            while (_waveText.color.a >= 0)
            {
                _alpha -= Time.deltaTime;
                _waveText.color = new Color(_waveText.color.r, _waveText.color.g, _waveText.color.b, _alpha);

                yield return null;
            }

            _waveText.gameObject.SetActive(false);
            _waveText.color = _waveTextColor;
        }
    }
}