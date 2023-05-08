using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemy {

    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _totalEnemiesToSpawn;

        private BoxCollider2D _spawnArea;
        private Vector2 _spawnAreaSize;

        private void Awake()
        {
            _spawnArea = GetComponent<BoxCollider2D>();

            _spawnAreaSize.x = _spawnArea.size.x;
            _spawnAreaSize.y = _spawnArea.size.y;
        }

        private void Start()
        {


            for (int i = _totalEnemiesToSpawn; i > 0; i--)
            {
                GameObject enemy = Instantiate(_prefab, GetPosition(), Quaternion.identity);
            }
        }

        private Vector2 GetPosition()
        {
            var newPos = new Vector2(Random.Range(-_spawnAreaSize.x / 2, _spawnAreaSize.x / 2), Random.Range(-_spawnAreaSize.y / 2, _spawnAreaSize.y /2));

            print(newPos.x + "/" +  newPos.y);

            return newPos;
        }
    }
}