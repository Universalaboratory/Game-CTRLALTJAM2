using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Player
{
    public class PlayerPowerUpHandler : MonoBehaviour
    {
        private Player _player;
        private PlayerHealth _playerHealth;

        private float _timer;

        private void Start()
        {
            _player = GetComponent<Player>();
            _playerHealth = GetComponent<PlayerHealth>();
        }

        public IEnumerator SettingDashPowerUp(float CoolDown, float newVelocity)
        {
            _timer = 0;
            var normalDashSpeed = _player.DashSpeed;
            _player.DashSpeed *= newVelocity;

            while (CoolDown >= _timer)
            {
                _timer += Time.deltaTime;
                yield return null;
            }
            _player.DashSpeed = normalDashSpeed;
        }

        public IEnumerator SettingSpeedPowerUp(float CoolDown, float newVelocity)
        {
            _timer = 0;
            var normalSpeed = _player.PlayerSpeed;
            _player.PlayerSpeed *= newVelocity;

            while (CoolDown >= _timer)
            {
                _timer += Time.deltaTime;
                yield return null;
            }
            _player.PlayerSpeed = normalSpeed;
        }

        public IEnumerator SettingLifePowerUp(float CoolDown, bool isOn)
        {
            _timer = 0;
            _playerHealth.CanDie = isOn;

            while (CoolDown >= _timer)
            {
                _timer += Time.deltaTime;
                yield return null;
            }

            _playerHealth.CanDie = !_playerHealth.CanDie;
        }

        public IEnumerator SettingDamagePowerUp(float CoolDown, float newDamage)
        {
            // Ainda não tem um sistema de Dano
            Debug.LogWarning("Ainda não tem sistema de dano");

            _timer = 0;

            while (CoolDown >= _timer)
            {
                _timer += Time.deltaTime;
                yield return null;
            }
            
        }
    }
}
