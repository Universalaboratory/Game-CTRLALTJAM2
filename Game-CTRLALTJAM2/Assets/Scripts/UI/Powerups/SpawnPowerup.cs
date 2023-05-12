using UI.PowerupSystem;
using UnityEngine;

namespace UI.PowerupSystem
{
    public class SpawnPowerup : MonoBehaviour
    {
        private PowerupList _powerUpList;

        [SerializeField] private bool _spawnAllPowerUp;
        [SerializeField] private float _timeBetweenSpawnSeconds = 3f;

        private float i = 0;

        void Start()
        {
            _powerUpList = GetComponent<PowerupList>();
        }

        void Update()
        {
            Spawn();
        }

        private void Spawn()
        {
            if (i < _timeBetweenSpawnSeconds)
                i += Time.deltaTime;
            else
            {
                if (_spawnAllPowerUp)
                {
                    _powerUpList.SpawnAllPowerUps(gameObject.transform.position);
                    i = 0;
                    return;
                }

                _powerUpList.SpawnOnePowerUpEachtime(gameObject.transform.position);
                i = 0;
            }
        }
    }
}