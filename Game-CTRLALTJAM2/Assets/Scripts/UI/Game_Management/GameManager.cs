using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GAMEPLAY,
    PAUSE
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

        public void ChangeState(GameState state)
        {
            _state = state;
        }
    }
}

