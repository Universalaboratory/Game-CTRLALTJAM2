using UnityEngine;

namespace Entities.Player
{
    public class CatchLoot : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.gameObject.tag)
            {
                case "Bread":
                    BreadEffect(other);
                    break;
                case "Popcorn":
                    PopcornEffect(other);
                    break;
                default:
                    break;
            }
        }

        private void BreadEffect(Collider2D self)
        {
            if (PlayerHealth._currentHealth < PlayerHealth._maxHelath)
            {
                float heal = PlayerHealth._maxHelath * 0.3f;
                PlayerHealth.RestoredLife(heal);
                Destroy(self.gameObject);
            }
            
        }

        private void PopcornEffect(Collider2D self)
        {
            if (PlayerHealth._currentHealth < PlayerHealth._maxHelath)
            {
                float heal = PlayerHealth._maxHelath * 0.1f;
                PlayerHealth.RestoredLife(heal);
                Destroy(self.gameObject);
            }
        }
    }
}