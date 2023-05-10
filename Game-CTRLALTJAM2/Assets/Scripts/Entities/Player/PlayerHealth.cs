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
        public static float _maxHelath;
        public static GameObject healthBar;
        public static Image filledHealthtBar;
        public static float _currentHealth;

        [Header("Test")]
        [SerializeField] private bool _canDie = true;

        public List<ParticleCollisionEvent> collisionEvents;


        private void Start()
        {
            _currentHealth = _maxHelath;

            collisionEvents = new List<ParticleCollisionEvent>();
        }

        private void OnParticleCollision(GameObject other)
        {
            if (!_canDie) return;

            LostLife(1);
        }

        private void LostLife(float damage)
        {
            _currentHealth -= damage;

            float fillAmountPercentage = _currentHealth / _maxHelath;

            filledHealthtBar.fillAmount = Mathf.Lerp(filledHealthtBar.fillAmount, fillAmountPercentage, 1);

            if (_currentHealth <= 0) Die();
        }

        public static void RestoredLife(float heal)
        {
            if ((_currentHealth + heal) >= _maxHelath)
                _currentHealth = _maxHelath;
            else
                _currentHealth += heal;

            float fillAmountPercentage = _currentHealth / _maxHelath;

            filledHealthtBar.fillAmount = Mathf.Lerp(filledHealthtBar.fillAmount, fillAmountPercentage, 1);
        }

        private void Die()
        {
            GameplayEvents.GameOver();
            //Debug.LogWarning("GAME OVER");
        }
    }
}

