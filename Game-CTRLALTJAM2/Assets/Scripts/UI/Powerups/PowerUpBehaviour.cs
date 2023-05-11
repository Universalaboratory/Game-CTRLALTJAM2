using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.PowerupSystem
{
    public class PowerUpBehaviour : MonoBehaviour
    {
        [SerializeField] public Powerups _powerUp;

        [HideInInspector] public SpriteRenderer _Sprite;
        [HideInInspector] public string _Name;
        [HideInInspector] public int _dropChance;
                          
        [HideInInspector] public float _value;
        [HideInInspector] public float _coolDownSeconds;
        [HideInInspector] public bool _isOn;

        private void Start()
        {
            _Sprite = GetComponent<SpriteRenderer>();

            _Sprite.sprite = _powerUp.Sprite;
            gameObject.tag = _powerUp.name;
            _dropChance = _powerUp.dropChance;

            _value = _powerUp.value;
            _coolDownSeconds = _powerUp.coolDownSeconds;
            _isOn = _powerUp.isOn;
        }
    }
}
