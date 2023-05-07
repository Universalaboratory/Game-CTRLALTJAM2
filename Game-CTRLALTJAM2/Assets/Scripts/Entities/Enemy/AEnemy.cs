using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Entities.Enemy
{
    public abstract class AEnemy : MonoBehaviour
    {
        [Space]
        [Header("Life Parameters")]
        [SerializeField] protected float maxHealth;
        [SerializeField] protected GameObject healthBar;
        [SerializeField] protected Image filledHealthtBar;
        protected float _currentHealth;

        [Space]
        [Header("Particle Parameters")]
        [SerializeField] public EnemyParticlePool _particlePrefab;
        [SerializeField] public Transform _bulletSpawn;
        [SerializeField] protected float _fireRate;
        protected EnemyParticleSpawner _particleSpawner;
        protected float timer;

        public abstract void TriggerEnter(GameObject player);
        public abstract void TriggerStay();
        public abstract void TriggerExit();

        protected abstract void MovementTowardsPlayer();
        protected abstract void PatrolMovement();
        protected abstract void AttackBehaviour();
        protected abstract void Die();

        protected virtual void HealthBarFiller(float damage)
        {
            _currentHealth -= damage;
            float fillAmountPercentage = _currentHealth / maxHealth;

            filledHealthtBar.fillAmount = Mathf.Lerp(filledHealthtBar.fillAmount, fillAmountPercentage, 1);
        }

        private void Awake()
        {

            healthBar.gameObject.SetActive(false);

            _currentHealth = maxHealth;
        }
    }
}

