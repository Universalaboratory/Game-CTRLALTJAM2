using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.LootSystem
{
    public class LootBehaviour : MonoBehaviour
    {
        [SerializeField] Loot _loot;

        [HideInInspector] public Sprite _lootSprite;
        [HideInInspector] public string _lootName;
        [HideInInspector] public int _dropChance;

        private void Start()
        {
            _lootSprite = _loot.Sprite;
            _lootName = _loot.Name;
            _dropChance = _loot.dropChance;
        }
    }
}

