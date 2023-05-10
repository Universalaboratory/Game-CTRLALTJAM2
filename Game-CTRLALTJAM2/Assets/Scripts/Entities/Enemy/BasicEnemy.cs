using UnityEngine;
using UI.GameManagement;
using UI.LootSystem;

namespace Entities.Enemy
{
    public class BasicEnemy : AEnemy
    {
        [Header("TEST")]
        [SerializeField] private bool _canDie = true;

        private void OnParticleCollision(GameObject other)
        {
            if (!_canDie) return;
                     
            healthBar.gameObject.SetActive(true);
            HealthBarFiller(1);
        }
    
        protected override void Die()
        {
            GetComponent<LootBag>().SpawnLoot(transform.position);
            GameplayEvents.EnemyDeath(this.gameObject);
            Destroy(gameObject);
        }
    }
}

