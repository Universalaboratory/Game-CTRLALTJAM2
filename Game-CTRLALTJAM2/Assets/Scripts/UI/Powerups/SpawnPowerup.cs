using UI.PowerupSystem;
using UnityEngine;

namespace UI.PowerupSystem
{
    public class SpawnPowerup : MonoBehaviour
    {
        private PowerupList _powerUpList; 

        private float i = 0;

        void Start ()
        {
            _powerUpList = GetComponent<PowerupList>();
        }

        void Update()
        {

            if (i < 3f)
                i += Time.deltaTime;
            else
            {
                //GetComponent<PowerupList>().SpawnPowerup(gameObject.transform.position);

                //Fazer o Spawn numa area determinada
                _powerUpList.SpawnAllPowerUps(gameObject.transform.position);
                i = 0;
            }
            
        }
    }
}