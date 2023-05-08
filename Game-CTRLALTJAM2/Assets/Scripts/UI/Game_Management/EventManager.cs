using UnityEngine;
using UnityEngine.Events;

// Namespace que centraliza todos os eventos do jogo.
namespace UI.GameManagement
{
    //public static class PlayerEvents
    //{
    //    public static event UnityAction PlayerHit;
    //    public static void OnPlayerHit() => PlayerHit?.Invoke();

    //    public static event UnityAction PlayerDeath;
    //    public static void OnPlayerDeath() => PlayerDeath?.Invoke();
    //}

    public static class ScoreEvents
    {
        public static event UnityAction<int> ScoreGained; // Manda
        public static void OnScoreGained(int value) => ScoreGained?.Invoke(value); // Recebe

        //public static event UnityAction<int> ChangeLevel;
        //public static void OnChangeLevel(int value) => ChangeLevel?.Invoke(value);
    }

    public static class GameplayEvents
    {
        public static event UnityAction<GameObject> EnemyDeath;
        public static void OnEnemyDeath(GameObject enemy) => EnemyDeath?.Invoke(enemy);


        public static event UnityAction GameOver;
        public static void OnGameOver() => GameOver?.Invoke();


        public static event UnityAction EndGame;
        public static void OnEndGame() => EndGame?.Invoke();
    }

    public static class UtilityEvents
    {
        //    public static event UnityAction SaveGame;
        //    public static void OnSaveGame() => SaveGame?.Invoke();

        public static event UnityAction GamePause;
        public static void OnGamePause() => GamePause?.Invoke();

        public static event UnityAction GameResume;
        public static void OnGameResume() => GameResume?.Invoke();

        //    public static event UnityAction<bool> SFXToggle;
        //    public static void OnMuteSFXToggle(bool isMute) => SFXToggle?.Invoke(isMute);

        //    public static event UnityAction<bool> BGMusicToggle;
        //    public static void OnBGMusicToggle(bool isMute) => BGMusicToggle?.Invoke(isMute);
    }
}