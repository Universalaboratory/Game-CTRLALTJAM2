using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GAMEPLAY,
    PAUSE,
    GAMEOVER
}

namespace UI.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameState _state;

        // Singleton Pattern
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        private void Start()
        {
            _state = GameState.GAMEPLAY;
        }

        private void OnEnable()
        {
            UtilityEvents.OnGamePause += GamePaused;
            UtilityEvents.OnGameResume += GameResumed;
            GameplayEvents.OnGameOver += GameOver;
        }

        private void OnDisable()
        {
            UtilityEvents.OnGamePause -= GamePaused;            
            UtilityEvents.OnGameResume -= GameResumed;
            GameplayEvents.OnGameOver -= GameOver;
        }

        public void ChangeState(GameState state)
        {
            _state = state;
        }

        private void GamePaused()
        {
            ChangeState(GameState.PAUSE);

            Time.timeScale = 0;
        }

        private void GameResumed()
        {
            ChangeState(GameState.GAMEPLAY);

            Time.timeScale = 1;
        }

        private void GameOver()
        {
            ChangeState(GameState.GAMEOVER);
        }
    }
}

