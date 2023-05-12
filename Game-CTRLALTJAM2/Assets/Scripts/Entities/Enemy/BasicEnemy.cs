using UnityEngine;
using UI.GameManagement;
using UI.LootSystem;
using Entities.Player;

namespace Entities.Enemy
{
    public class BasicEnemy : AEnemy
    {


        //private void OnParticleCollision(GameObject other)
        //{
        //    if (!_canDie) return;

        //    var damage = other.GetComponent<ParticleDamageSystem>().Damage;

        //    //Debug.LogWarning(damage);
        //    healthBar.gameObject.SetActive(true);
        //    HealthBarFiller(damage);
        //}
    
        protected override void Die()
        {
            GetComponent<LootBag>().SpawnLoot(transform.position);
            GameplayEvents.EnemyDeath(this.gameObject);
            Destroy(gameObject);
        }
    }
}

