using UI.PowerupSystem;
using UnityEngine;

namespace UI.PowerupSystem
{
    public class SpawnPowerup : MonoBehaviour
    {
        private float i;

        void Start ()
        {
            i = 0;
        }

        void Update()
        {

            if (i < 7f)
                i += Time.deltaTime;
            else
            {
                GetComponent<PowerupList>().SpawnPowerup(gameObject.transform.position);
                i = 0;
            }
            
        }
    }
}