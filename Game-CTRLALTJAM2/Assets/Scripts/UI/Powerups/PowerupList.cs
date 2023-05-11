using System.Collections.Generic;
using UnityEngine;

namespace UI.PowerupSystem
{
    public class PowerupList : MonoBehaviour
    {
        public GameObject droppedPowerupPrefab;
        public List<Powerups> powerupList = new List<Powerups>();
        
        List<Powerups> droppedItem;

        List<Powerups> GetDroppedPowerup()
        {
            int randNum = Random.Range(0, 100);
            List<Powerups> possibleDrops = new List<Powerups>();

            foreach (Powerups powerup in powerupList)
            {
                if (randNum <= powerup.dropChance)
                {
                    possibleDrops.Add(powerup);
                }
            }

            if (possibleDrops.Count > 0)
            {
                return possibleDrops;
            }
            else
            {
                return null;
            }
        }

        public void SpawnPowerup(Vector3 spawnerPos)
        {
            droppedItem = GetDroppedPowerup();

            if (droppedItem != null)
            {
                for (int i = 0; i < droppedItem.Count; i++)
                {
                    Vector3 powerPos = new Vector3(spawnerPos.x + Random.Range(-7.5f, 7.5f), spawnerPos.y + Random.Range(-4.5f, 4.5f), 0);
                    GameObject newPowerup = Instantiate(droppedPowerupPrefab, powerPos, Quaternion.identity);
                    newPowerup.gameObject.tag = droppedItem[i].powerupName;
                    print(newPowerup.gameObject.tag);
                    newPowerup.GetComponent<SpriteRenderer>().sprite = droppedItem[i].powerupSprite;
                }
            }
        }
    }
}