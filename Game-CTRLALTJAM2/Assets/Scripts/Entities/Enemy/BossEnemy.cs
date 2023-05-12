using UnityEngine;
using UI.LootSystem;
using UI.GameManagement;

namespace Entities.Enemy
{
    public class BossEnemy : AEnemy
    {
        protected override void Die()
        {            
            GameplayEvents.WinGame();
            Destroy(gameObject);
        }
    }
}