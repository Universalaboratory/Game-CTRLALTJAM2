using UnityEngine;

namespace UI.PowerupSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PowerUp")]
    public class Powerups : ScriptableObject
    {
        public Sprite Sprite;
        public string Name;
        public int dropChance;

        public float value;
        public float coolDownSeconds;
        public bool isOn;

        //public Powerups(string powerupName, int dropChance, float value, float coolDown, bool isOn)
        //{
        //    this.Name = powerupName;
        //    this.dropChance = dropChance;

        //    this.value = value;
        //    this.coolDownSeconds = coolDown;
        //    this.isOn = isOn;
        //}
    }
}