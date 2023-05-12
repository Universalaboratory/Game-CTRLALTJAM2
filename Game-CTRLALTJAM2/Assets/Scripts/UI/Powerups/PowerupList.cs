using System.Collections.Generic;
using UnityEngine;

namespace UI.PowerupSystem
{
    public class PowerupList : MonoBehaviour
    {
        public List<GameObject> powerupList = new List<GameObject>();
        
        public void SpawnAllPowerUps(Vector2 pos)
        {
            foreach (var powerUp in powerupList)
            {
                var PUDropChance = powerUp.GetComponent<PowerUpBehaviour>()._powerUp.dropChance;

                var rndDropChance = Random.Range(0, 100);

                if (PUDropChance > rndDropChance)
                {

                    GameObject newPowerUp = Instantiate(powerUp, GetRandomPosition(pos), Quaternion.identity);
                }
            }
        }

        public void SpawnOnePowerUpEachtime(Vector2 pos)
        {
            var rnd = Random.Range(0, powerupList.Count);

            GameObject newPowerUp = Instantiate(powerupList[rnd], GetRandomPosition(pos), Quaternion.identity);
        }

        // Fazer o local do Spawn ser mais específico
        private Vector2 GetRandomPosition(Vector2 spawnerPos)
        {
            return new Vector2(spawnerPos.x + Random.Range(-7.5f, 7.5f), spawnerPos.y + Random.Range(-4.5f, 4.5f));
        }
    }
}