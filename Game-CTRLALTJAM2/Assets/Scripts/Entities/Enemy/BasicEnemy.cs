using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemy
{
    public class BasicEnemy : AEnemy
    {



        void Start()
        {

        }

        void Update()
        {
            LostHealth();
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
            Debug.LogWarning("Achou o Player");
        }

        public override void TriggerExit()
        {
            
        }

        public override void TriggerStay()
        {
            
        }

        protected override void AttackBehaviour()
        {
            
        }

        protected override void Die()
        {
            Destroy(gameObject);
        }

        protected override void MovementTowardsPlayer()
        {
            
        }

        protected override void PatrolMovement()
        {
            
        }

     
    }
}

