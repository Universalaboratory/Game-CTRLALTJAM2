using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Audio;

//REMOVER ENEMY SPAWN CLASS NA PASTA 

namespace UI.GameManagement
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Prefab List")]
        [SerializeField] private GameObject[] _prefabEnemyList;
        [SerializeField] private GameObject _prefabBoss;

        [Space]
        [SerializeField] private int _enemiesToSpawnPerWave;
        [SerializeField] private List<GameObject> _liveEnemyList = new List<GameObject>();

        private WaveManager _waveManager;

        private BoxCollider2D _spawnArea;
        private Vector2 _spawnAreaSize;

        private void Awake()
        {
            _waveManager = GetComponent<WaveManager>();

            _spawnArea = GetComponent<BoxCollider2D>();
            _spawnAreaSize.x = _spawnArea.size.x;
            _spawnAreaSize.y = _spawnArea.size.y;
        }

        private void OnEnable()
        {
            GameplayEvents.OnNextWave += SpawnEnemy;
            GameplayEvents.OnBoss += SpawnBoss;
            GameplayEvents.OnEnemyDeath += RemoveEnemyFromList;
        }

        private void OnDisable()
        {

            GameplayEvents.OnNextWave -= SpawnEnemy;
            GameplayEvents.OnBoss -= SpawnBoss;
            GameplayEvents.OnEnemyDeath -= RemoveEnemyFromList;
        }

        private Vector2 GetPosition()
        {
            var newPos = new Vector2(Random.Range(-_spawnAreaSize.x / 2, _spawnAreaSize.x / 2), Random.Range(-_spawnAreaSize.y / 2, _spawnAreaSize.y / 2));
            return newPos;
        }

        private void SpawnEnemy(WaveState currentWave)
        {
            var totalEnemiesToSpawn = _enemiesToSpawnPerWave + (int)currentWave;

            for (int i = 0; i < totalEnemiesToSpawn; i++)
            {
                var enemyToSpawn = Random.Range(0, _prefabEnemyList.Length);

                GameObject enemy = Instantiate(_prefabEnemyList[enemyToSpawn], GetPosition(), Quaternion.identity);
                AddEnemyToList(enemy);
            }
        }

        private void SpawnBoss()
        {
            // Posição randomica
            //GameObject enemy = Instantiate(_prefabBoss, GetPosition(), Quaternion.identity);            
            
            GameObject.FindFirstObjectByType<AudioManager>().CleanUp();
            GameObject.FindFirstObjectByType<AudioManager>().InitializeMusic(FMODEvents.instance.bossMusic);
            
            // Centro da Tela
            GameObject enemy = Instantiate(_prefabBoss, Vector3.zero, Quaternion.identity);
        }

        private void AddEnemyToList(GameObject enemy)
        {
            _liveEnemyList.Add(enemy);
        }

        private void RemoveEnemyFromList(GameObject enemy)
        {
            _liveEnemyList.Remove(enemy);
            CheckTotalEnemyAlive();
        }

        private void CheckTotalEnemyAlive()
        {
            if (_liveEnemyList.Count == 0)
                _waveManager.NextWave();
        }
    }

}

