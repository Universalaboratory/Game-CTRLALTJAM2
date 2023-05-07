using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemy {

    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private BoxCollider2D _spawnArea;

        [SerializeField] private Vector2 _spawnAreaSize;

        public Vector2 newPos;

        private void Awake()
        {
            _spawnAreaSize.x = _spawnArea.size.x;
            _spawnAreaSize.y = _spawnArea.size.y;
        }

        private void Start()
        {
            for (int i = 3; i > 0; i--)
            {
                GameObject enemy = Instantiate(_prefab, GetPosition(), Quaternion.identity);
            }
        }

        private Vector2 GetPosition()
        {
            newPos = new Vector2(Random.Range(-_spawnAreaSize.x / 2, _spawnAreaSize.x / 2), Random.Range(-_spawnAreaSize.y / 2, _spawnAreaSize.y /2));

            print(newPos.x + "/" +  newPos.y);

            return newPos;
        }
    }
}