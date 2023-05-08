using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//REMOVER ENEMY SPAWN CLASS NA PASTA 

namespace UI.GameManagement
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _totalEnemiesToSpawn;
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

        private void Start()
        {
            for (int i = _totalEnemiesToSpawn; i > 0; i--)
            {
                GameObject enemy = Instantiate(_prefab, GetPosition(), Quaternion.identity);
                AddEnemyToList(enemy);
            }
        }

        private void OnEnable()
        {
            GameplayEvents.EnemyDeath += RemoveEnemyFromList;
        }

        private void OnDisable()
        {
            GameplayEvents.EnemyDeath -= RemoveEnemyFromList;            
        }

        private Vector2 GetPosition()
        {
            var newPos = new Vector2(Random.Range(-_spawnAreaSize.x / 2, _spawnAreaSize.x / 2), Random.Range(-_spawnAreaSize.y / 2, _spawnAreaSize.y / 2));

            print(newPos.x + "/" + newPos.y);

            return newPos;
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
            {
                _waveManager.NextWave();
            }
        }

    }

}

