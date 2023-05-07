using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemy
{
    public class BasicEnemy : AEnemy
    {

      

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
           
        }

        public override void TriggerExit()
        {
            
        }

        public override void TriggerStay()
        {
            
        }


        // Usar essa fun��o pra atirar. 
        // Fazer o inimigo rotacionar em dire��o ao jogador
        // por enquanto o imigo n�o atira, poq n�o v� o jogador
        protected override void AttackBehaviour()
        {
            timer += Time.deltaTime;

            float nextTimeToFire = 1 / _fireRate;

            if (timer >= nextTimeToFire)
            {
                _particleSpawner._pool.Get();
                timer = 0;
            }
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

