using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameManagement
{

    public class UIHUDManager : MonoBehaviour
    {
        [SerializeField] private Image _dashFillBar;

        private void OnEnable()
        {
            GameplayEvents.OnDash += SettingDashBar;
        }

        private void OnDisable()
        {
            GameplayEvents.OnDash -= SettingDashBar;
        }

        private void SettingDashBar(float coolDownTimerSeconds)
        {
            _dashFillBar.fillAmount = 0;
            StartCoroutine(FillDashBar(coolDownTimerSeconds));
        }

        private IEnumerator FillDashBar(float coolDownTimerSeconds)
        {
            Debug.LogWarning("Começou Timer");

            while (_dashFillBar.fillAmount != 1)
            {
                _dashFillBar.fillAmount += 1 / coolDownTimerSeconds * Time.deltaTime;
                yield return null;
            }

            Debug.LogWarning("Terminou Timer");

        }
    }
}

