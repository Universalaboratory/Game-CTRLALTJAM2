using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.LootSystem
{
    [CreateAssetMenu]
    public class Loot : ScriptableObject
    {
        public Sprite lootSprite;
        public string lootName;
        public int dropChance;

        public Loot(string lootName, int dropChance)
        {
            this.lootName = lootName;
            this.dropChance = dropChance;
        }
    }
}