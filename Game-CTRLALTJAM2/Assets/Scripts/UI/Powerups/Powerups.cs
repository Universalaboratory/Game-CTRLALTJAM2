using UnityEngine;

namespace UI.PowerupSystem
{
    [CreateAssetMenu]
    public class Powerups : ScriptableObject
    {
        public Sprite powerupSprite;
        public string powerupName;
        public int dropChance;

        public Powerups(string powerupName, int dropChance)
        {
            this.powerupName = powerupName;
            this.dropChance = dropChance;
        }
    }
}