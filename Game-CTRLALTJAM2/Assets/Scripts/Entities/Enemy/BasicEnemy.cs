using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemy
{
    public class BasicEnemy : AEnemy
    {
        [Header("Movement Parameters")]
        [SerializeField] private float _basicEnemySpeed;
      

        private void Update()
        {
            LostHealth();
            EnemyLook(_target.position);
            MovementTowardsPlayer();
            AttackBehaviour();
        }

        private void OnParticleCollision(GameObject other)
        {
            healthBar.gameObject.SetActive(true);
            HealthBarFiller(1);
        }

        private void LostHealth()
        {
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        public override void TriggerEnter(GameObject player)
        {
            _isPlayerInRange = true;
            Debug.LogWarning("Player In Range");
        }


        // ainda não tá funcionando como deveria
        public override void TriggerExit()
        {

            Debug.LogWarning("Player Out of Range");
            _isPlayerInRange = false;
        }

        public override void TriggerStay()
        {
            
        }


        // Achar o mínimo de distância pra atacar
        protected override void AttackBehaviour()
        {
            if (!_isPlayerInRange) return;

            timer += Time.deltaTime;

            float nextTimeToFire = 1 / _fireRate;

            if (timer >= nextTimeToFire)
            {
                _particleSpawner._pool.Get();
                timer = 0;
            }
        }

        // Enquanto estiver atacando, desabilita o movimento
        protected override void MovementTowardsPlayer()
        {
            if (_isPlayerInRange) _rb.velocity = Vector2.zero;
        
            var dir = _target.position - transform.position;
            _rb.velocity = new Vector2(dir.x * _basicEnemySpeed, dir.y * _basicEnemySpeed);
        }

        protected override void Die()
        {
            Destroy(gameObject);
        }

        protected override void PatrolMovement()
        {
            
        }

    }
}

