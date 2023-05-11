using UnityEngine;

namespace Entities.Player
{
    public class CatchLoot : MonoBehaviour
    {
        private Player _player;
        private PlayerHealth _playerHealth;

        private void Start()
        {
            _player = GetComponent<Player>();
             _playerHealth = GetComponent<PlayerHealth>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            switch (other.gameObject.tag)
            {
                case "Bread":
                    BreadEffect(other);
                    break;
                case "Popcorn":
                    PopcornEffect(other);
                    break;
                case "Dash":
                    DashEffect(other);
                    break;
                case "IncreaseLife":
                    IncLifeEffect(other);
                    break;
                case "IncreaseSpeed":
                    IncSpeedEffect(other);
                    break;
                case "IncreaseDamage":
                    IncDamageEffect(other);
                    break;
                default:
                    break;
            }
        }


        private void BreadEffect(Collider2D self)
        {
            if (_playerHealth._currentHealth < _playerHealth._maxHelath)
            {
                float heal = _playerHealth._maxHelath * 0.3f;

                _playerHealth.RestoredLife(heal);
                Destroy(self.gameObject);
            }            
        }

        private void PopcornEffect(Collider2D self)
        {
            if (_playerHealth._currentHealth < _playerHealth._maxHelath)
            {
                float heal = _playerHealth._maxHelath * 0.1f;

                _playerHealth.RestoredLife(heal);
                Destroy(self.gameObject);
            }
        }

        private void DashEffect(Collider2D self)
        {
            // Reduz o tempo de Cool Down E
            // Aumenta a Velocidade

            //_player.DashCoolDownTimeSeconds = 



            Destroy(self.gameObject);
        }

        private void IncLifeEffect(Collider2D self)
        {
            Debug.LogWarning("PEGOU VIDA");
            Destroy(self.gameObject);
        }

        private void IncSpeedEffect(Collider2D self)
        {
            Debug.LogWarning("PEGOU SPEED");
            Destroy(self.gameObject);
        }

        private void IncDamageEffect(Collider2D self)
        {
            Debug.LogWarning("PEGOU DAMAGE");
            Destroy(self.gameObject);
        }
    }
}