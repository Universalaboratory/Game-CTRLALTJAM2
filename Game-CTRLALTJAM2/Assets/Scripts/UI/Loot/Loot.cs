using UnityEngine;

namespace UI.LootSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Loot")]
    public class Loot : ScriptableObject
    {
        public Sprite Sprite;
        public string Name;
        public int dropChance;

        //public Loot(string lootName, int dropChance)
        //{
        //    this.Name = lootName;
        //    this.dropChance = dropChance;
        //}
    }
}