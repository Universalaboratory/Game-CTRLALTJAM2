using UnityEngine;
using Utilities;
using UI.GameManagement;

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
                case Constants.BREAD:
                    BreadEffect(other);
                    break;
                case Constants.POPCORN:
                    PopcornEffect(other);
                    break;
                case Constants.DASH:
                    DashEffect(other);
                    break;
                case Constants.INCREASE_LIFE:
                    IncLifeEffect(other);
                    break;
                case Constants.INCREASE_SPEED:
                    IncSpeedEffect(other);
                    break;
                case Constants.INCREASE_DAMAGE:
                    IncDamageEffect(other);
                    break;
                default:
                    break;
            }
        }


        private void BreadEffect(Collider2D self)
        {
            if (_playerHealth.CurrentHealth < _playerHealth.MaxHealth)
            {
                float heal = _playerHealth.MaxHealth * 0.3f;

                _playerHealth.RestoredLife(heal);
                Destroy(self.gameObject);
            }            
        }

        private void PopcornEffect(Collider2D self)
        {
            if (_playerHealth.CurrentHealth < _playerHealth.MaxHealth)
            {
                float heal = _playerHealth.MaxHealth * 0.1f;

                _playerHealth.RestoredLife(heal);
                Destroy(self.gameObject);
            }
        }

        private void DashEffect(Collider2D self)
        {
            // Tempo cool down
            // aumentar velocidade

            Debug.LogWarning("PEGOU DASH");
            GameplayEvents.PowerUp(5f);

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