using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using UI.GameManagement;

namespace Entities.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float _maxHelath;
        [SerializeField] protected GameObject healthBar;
        [SerializeField] protected Image filledHealthtBar;
        private float _currentHealth;

        public ParticleSystem part;
        public List<ParticleCollisionEvent> collisionEvents;


        private void Start()
        {


            _currentHealth = _maxHelath;

            collisionEvents = new List<ParticleCollisionEvent>();
        }

        private void OnParticleCollision(GameObject other)
        {
            LostLife(1);
        }

        private void LostLife(float damage)
        {
            _currentHealth -= damage;
            float fillAmountPercentage = _currentHealth / _maxHelath;

            filledHealthtBar.fillAmount = Mathf.Lerp(filledHealthtBar.fillAmount, fillAmountPercentage, 1);

            if (_currentHealth <= 0) Die();
        }


        private void Die()
        {
            //Debug.LogWarning("GAME OVER");
        }
    }
}

