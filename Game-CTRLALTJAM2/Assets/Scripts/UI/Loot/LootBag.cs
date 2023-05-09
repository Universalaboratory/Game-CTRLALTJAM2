using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.LootSystem
{
    public class LootBag : MonoBehaviour
    {
        public GameObject droppedItemPrefab;
        public List<Loot> lootList = new List<Loot>();

        List<Loot> GetDroppedItem()
        {
            int randNum = Random.Range(0, 100);
            List<Loot> possibleItens = new List<Loot>();

            foreach (Loot loot in lootList)
            {
                if (randNum <= loot.dropChance)
                {
                    possibleItens.Add(loot);
                }
            }

            if (possibleItens.Count > 0)
            {
                return possibleItens;
            }
            else
            {
                return null;
            }
        }

        public void SpawnLoot(Vector3 lootPos)
        {
            List<Loot> droppedItem = GetDroppedItem();

            if (droppedItem != null)
            {
                for (int i = 0; i < droppedItem.Count; i++)
                {
                    Vector3 newPos = new Vector3(lootPos.x + Random.Range(-1, 1), lootPos.y + Random.Range(-1, 1), 0);
                    GameObject newLoot = Instantiate(droppedItemPrefab, newPos, Quaternion.identity);
                    newLoot.GetComponent<SpriteRenderer>().sprite = droppedItem[i].lootSprite;
                }
            }
                
        }
    }
}