using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Entities.Enemy
{
    public abstract class AEnemy : MonoBehaviour
    {        
        [SerializeField] protected float maxHealth;

        [Space]
        [SerializeField] protected GameObject healthBar;
        [SerializeField] private Image filledHealthtBar;

        protected float _currentHealth;

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
            //_rb = GetComponent<Rigidbody2D>();
            //anim = GetComponent<Animator>();
            healthBar.gameObject.SetActive(false);

            //_state = State.Sleep;
            _currentHealth = maxHealth;
        }
    }
}

