using UnityEngine;

namespace UI.LootSystem
{
    public class CatchLoot : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                LootEffect();
                Destroy(gameObject);
            }
        }

        private void LootEffect()
        {
            switch (gameObject.tag)
            {
                case "Bread":
                    print(gameObject.tag);
                    break;
                case "Popcorn":
                    print(gameObject.tag);
                    break;
                default:
                    break;
            }
        }
    }
}