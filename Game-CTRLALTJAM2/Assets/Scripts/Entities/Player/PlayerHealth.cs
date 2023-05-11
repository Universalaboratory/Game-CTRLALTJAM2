using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using UI.GameManagement;
using Cinemachine;


namespace Entities.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public float _maxHelath;
        public GameObject healthBar;
        public Image filledHealthtBar;
        public float _currentHealth;

        [Header("Test")]
        [SerializeField] private bool _canDie = true;

        public bool CanDie { get => _canDie; set => _canDie = value; }

        private List<ParticleCollisionEvent> collisionEvents;

        private CinemachineImpulseSource _impulseSource;


        private void Start()
        {
            _currentHealth = _maxHelath;

            collisionEvents = new List<ParticleCollisionEvent>();
            _impulseSource = GetComponent<CinemachineImpulseSource>();
        }

        private void OnParticleCollision(GameObject other)
        {
            if (!_canDie) return;

            CameraShakeManager.Instance.CameraShake(_impulseSource);
            LostLife(1);
        }

        private void LostLife(float damage)
        {
            _currentHealth -= damage;

            float fillAmountPercentage = _currentHealth / _maxHelath;

            filledHealthtBar.fillAmount = Mathf.Lerp(filledHealthtBar.fillAmount, fillAmountPercentage, 1);

            if (_currentHealth <= 0) Die();
        }

        public void RestoredLife(float heal)
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

