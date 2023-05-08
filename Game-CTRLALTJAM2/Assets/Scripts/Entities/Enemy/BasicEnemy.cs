using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.GameManagement;

namespace Entities.Enemy
{
    public class BasicEnemy : AEnemy
    {
        [Header("Movement Parameters")]
        [SerializeField] private float _basicEnemySpeed;

        [Header("TEST")]
        [SerializeField] private bool _ISCOLLIDING;

        private void OnParticleCollision(GameObject other)
        {
            if (!_ISCOLLIDING) return;
           
            
            healthBar.gameObject.SetActive(true);
            HealthBarFiller(1);
        }

        protected override void LostHealth()
        {
            if (_currentHealth <= 0) Die();
        }

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

        protected override void MovementTowardsPlayer()
        {
            if (_isPlayerInRange)
            {
                _rb.velocity = Vector2.zero;
                return;
            }

            _distanceToPlayer = _target.position - transform.position;
            var distNormilize = _distanceToPlayer.normalized;
            _rb.velocity = new Vector2(distNormilize.x * _basicEnemySpeed, distNormilize.y * _basicEnemySpeed);
        }

        protected override void VerifyRange()
        {
            var distX = Mathf.Abs(_distanceToPlayer.x);
            var distY = Mathf.Abs(_distanceToPlayer.y);

            _isPlayerInRange = (distX < _minDistToAttack && distY < _minDistToAttack) ? true : false;
        }

        protected override void PatrolMovement()
        {

        }

        protected override void Die()
        {
            GameplayEvents.OnEnemyDeath(this.gameObject);
            Destroy(gameObject);
        } 
    }
}

