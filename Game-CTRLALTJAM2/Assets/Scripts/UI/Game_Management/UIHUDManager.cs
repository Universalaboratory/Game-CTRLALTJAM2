using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameManagement
{

    public class UIHUDManager : MonoBehaviour
    {
        [Header("PowerUp")]
        [SerializeField] private GameObject _powerUpBarHolder;
        [SerializeField] private Image _powerUpFillBar;

        [Space]
        [Header("Dash")]
        [SerializeField] private Image _dashFillBar;

        private void Start()
        {
            _powerUpBarHolder.SetActive(false);
        }

        private void OnEnable()
        {
            GameplayEvents.OnDash += SettingDashBar;
            GameplayEvents.OnPowerUp += SettingPowerUpBar;
        }

        private void OnDisable()
        {
            GameplayEvents.OnDash -= SettingDashBar;
            GameplayEvents.OnPowerUp -= SettingPowerUpBar;
        }

        private void SettingDashBar(float coolDownTimerSeconds)
        {
            _dashFillBar.fillAmount = 0;
            StartCoroutine(FillDashBar(coolDownTimerSeconds));
        }

        private IEnumerator FillDashBar(float coolDownTimerSeconds)
        {
            while (_dashFillBar.fillAmount != 1)
            {
                _dashFillBar.fillAmount += 1 / coolDownTimerSeconds * Time.deltaTime;
                yield return null;
            }
        }

        private void SettingPowerUpBar(float coolDownTimerSeconds)
        {
            _powerUpBarHolder.SetActive(true);

            _powerUpFillBar.fillAmount = 1;
            StartCoroutine(FillPowerUpBar(coolDownTimerSeconds));
        }

        private IEnumerator FillPowerUpBar(float coolDownTimerSeconds)
        {
            while (_powerUpFillBar.fillAmount != 0)
            {
                _powerUpFillBar.fillAmount -= 1 / coolDownTimerSeconds * Time.deltaTime;
                yield return null;
            }
            _powerUpBarHolder.SetActive(false);
        }

    }
}

