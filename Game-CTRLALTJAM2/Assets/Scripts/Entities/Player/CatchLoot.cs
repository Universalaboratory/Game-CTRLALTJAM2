using UnityEngine;

namespace Entities.Player
{
    public class CatchLoot : MonoBehaviour
    {
        private PlayerHealth _playerHealth;

        private void Start()
        {
             _playerHealth = GetComponent<PlayerHealth>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Bread":
                    BreadEffect(collision);
                    break;
                case "Popcorn":
                    PopcornEffect(collision);
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
    }
}