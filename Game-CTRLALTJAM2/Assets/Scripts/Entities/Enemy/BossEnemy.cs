using UnityEngine;
using UI.LootSystem;
using UI.GameManagement;

namespace Entities.Enemy
{
    public class BossEnemy : AEnemy
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
            GameplayEvents.WinGame();
            Destroy(gameObject);
        }
    }
}