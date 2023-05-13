using UnityEngine;
using UI.GameManagement;
using UI.Audio;

namespace Entities.Enemy
{
    public class BossEnemy : AEnemy
    {


        protected override void Die()
        {
            GameObject.FindObjectOfType<AudioManager>().CleanUp();
            GameplayEvents.WinGame();
            Destroy(gameObject);
        }
    }
}