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
            VerifyRange();
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
        
            _distanceToPlayer = _target.position - transform.position;
            var distNormilize = _distanceToPlayer.normalized;
            _rb.velocity = new Vector2(distNormilize.x * _basicEnemySpeed, distNormilize.y * _basicEnemySpeed);
        }

        protected override void Die()
        {
            Destroy(gameObject);
        }

        protected override void PatrolMovement()
        {
            
        }

        protected override void VerifyRange()
        {

            // Acertar essa distancia. 
            // Criar um Draw line pra debugar melhor 
            if (_distanceToPlayer.x < _minDistToAttack || _distanceToPlayer.y < _minDistToAttack)
            {
                Debug.LogWarning("IN RANGE");
                _isPlayerInRange = true;
            }
            else
            {
                Debug.LogWarning("OUT OF RANGE");
                _isPlayerInRange = false;
            }
        }
    }
}

