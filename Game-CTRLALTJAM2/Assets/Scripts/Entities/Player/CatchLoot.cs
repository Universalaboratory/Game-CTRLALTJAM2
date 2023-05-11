using UnityEngine;
using Utilities;
using UI.GameManagement;
using UI.LootSystem;
using UI.PowerupSystem;

namespace Entities.Player
{
    public class CatchLoot : MonoBehaviour
    {
        private Player _player;
        private PlayerPowerUpHandler _playerPowerUpHandler;
        private PlayerHealth _playerHealth;

        private void Start()
        {
            _player = GetComponent<Player>();
             _playerHealth = GetComponent<PlayerHealth>();
            _playerPowerUpHandler = GetComponent<PlayerPowerUpHandler>();
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
                case Constants.INCREASE_DASH:
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
            var values = self.gameObject.GetComponent<PowerUpBehaviour>();

            var coolDown = values._coolDownSeconds;
            var newSpeed = values._value;

            StartCoroutine(_playerPowerUpHandler.SettingDashPowerUp(coolDown, newSpeed));
            GameplayEvents.PowerUp(coolDown);

            Destroy(self.gameObject);
        }

        private void IncLifeEffect(Collider2D self)
        {
            var values = self.gameObject.GetComponent<PowerUpBehaviour>();

            var coolDown = values._coolDownSeconds;
            var isOn = values._isOn;

            StartCoroutine(_playerPowerUpHandler.SettingLifePowerUp(coolDown, isOn));
            GameplayEvents.PowerUp(coolDown);

            Destroy(self.gameObject);
        }

        private void IncSpeedEffect(Collider2D self)
        {
            var values = self.gameObject.GetComponent<PowerUpBehaviour>();

            var coolDown = values._coolDownSeconds;
            var newSpeed = values._value;

            StartCoroutine(_playerPowerUpHandler.SettingSpeedPowerUp(coolDown, newSpeed));
            GameplayEvents.PowerUp(coolDown);

            Destroy(self.gameObject);
        }

        private void IncDamageEffect(Collider2D self)
        {
            var values = self.gameObject.GetComponent<PowerUpBehaviour>();

            var coolDown = values._coolDownSeconds;
            var newDamage= values._value;

            StartCoroutine(_playerPowerUpHandler.SettingDamagePowerUp(coolDown, newDamage));
            GameplayEvents.PowerUp(coolDown);

            Destroy(self.gameObject);
        }
    }
}