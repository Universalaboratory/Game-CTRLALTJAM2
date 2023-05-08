using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Entities.Player
{
    public class ParticleSpawner : MonoBehaviour
    {
        public ObjectPool<ParticlePool> _pool;

        private PlayerShootBehaviour _playerShootBehaviour;

        private void Start()
        {
            _playerShootBehaviour = GetComponent<PlayerShootBehaviour>();
            _pool = new ObjectPool<ParticlePool>(CreateParticles, OnTakeParticleFromPool, OnReturnParticleToPool, OnDestroyParticles, true, 200, 350);
        }

        private ParticlePool CreateParticles()
        {
            ParticlePool particles = Instantiate(_playerShootBehaviour._particlePrefab, _playerShootBehaviour._bulletSpawn.position, _playerShootBehaviour._bulletSpawn.rotation);
            particles.transform.SetParent(_playerShootBehaviour._bulletSpawn);
            particles.SetPool(_pool);
            return particles;
        }

        private void OnTakeParticleFromPool(ParticlePool particles)
        {
            particles.transform.position = _playerShootBehaviour._bulletSpawn.position;
            particles.transform.rotation = _playerShootBehaviour._bulletSpawn.rotation;

            particles.gameObject.SetActive(true);
        }

        private void OnReturnParticleToPool(ParticlePool particles)
        {
            particles.gameObject.SetActive(false);

        }

        private void OnDestroyParticles(ParticlePool particles)
        {
            Destroy(particles.gameObject);
        }

    }

}

