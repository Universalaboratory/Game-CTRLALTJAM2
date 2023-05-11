using System.Collections.Generic;
using UnityEngine;

namespace UI.PowerupSystem
{
    public class PowerupList : MonoBehaviour
    {
        public List<GameObject> powerupList = new List<GameObject>();
        
        List<GameObject> droppedItem;

        public void SpawnAllPowerUps(Vector2 pos)
        {
            Debug.LogWarning("SPAWN ALL PU");

            foreach (var powerUp in powerupList)
            {
                var PUDropChance = powerUp.GetComponent<PowerUpBehaviour>()._powerUp.dropChance;

                var rndDropChance = Random.Range(0, 100);

                Debug.LogWarning($"Drop Chance = {PUDropChance}, Random = {rndDropChance}");

                if (PUDropChance > rndDropChance)
                {

                    GameObject newPowerUp = Instantiate(powerUp, GetRandomPosition(pos), Quaternion.identity);
                    Debug.LogWarning($"Criou {newPowerUp}");
                }
            }
        }

        private Vector2 GetRandomPosition(Vector2 spawnerPos)
        {
            return new Vector2(spawnerPos.x + Random.Range(-7.5f, 7.5f), spawnerPos.y + Random.Range(-4.5f, 4.5f));
        }

        //private GameObject GetDroppedPowerup()
        //{
        //    int randNum = Random.Range(0, 100);
        //    droppedItem = new List<GameObject>();

        //    foreach (var powerup in powerupList)
        //    {
        //        var drop = powerup.GetComponent<PowerUpBehaviour>()._dropChance;

        //        if (randNum <= drop)
        //        {
        //            droppedItem.Add(powerup);
        //        }
        //    }



        //}

        //public void SpawnPowerup(Vector3 spawnerPos)
        //{
        //    droppedItem = GetDroppedPowerup();

        //    if (droppedItem != null)
        //    {
        //        for (int i = 0; i < droppedItem.Count; i++)
        //        {
        //            Vector3 powerPos = new Vector3(spawnerPos.x + Random.Range(-7.5f, 7.5f), spawnerPos.y + Random.Range(-4.5f, 4.5f), 0);
        //            GameObject newPowerup = Instantiate(powerupList[i], powerPos, Quaternion.identity);
        //            //newPowerup.gameObject.tag = droppedItem[i].powerupName;
        //            //print(newPowerup.gameObject.tag);
        //            //newPowerup.GetComponent<SpriteRenderer>().sprite = droppedItem[i].powerupSprite;

        //            Debug.LogWarning("SPawn PU");
        //        }
        //    }
        //}
    }
}