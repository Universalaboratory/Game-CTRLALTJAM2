using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Entities.Enemy
{
    public class EnemyTriggerArea : MonoBehaviour
    {
        AEnemy _myEnemy;

        private void Start()
        {
            _myEnemy = GetComponentInParent<AEnemy>();

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Constants.PLAYER_TAG))
            {
                GameObject player = collision.transform.gameObject;

                Debug.LogWarning("ACHOU PLAYER");

                _myEnemy.TriggerEnter(player);
            }
        }


        //private void OnTriggerStay2D(Collider other) => _myEnemy.TriggerStay();

        //private void OnTriggerExit2D(Collider other) => _myEnemy.TriggerExit();

        private void OnTriggerStay2D(Collider2D collision) => _myEnemy.TriggerStay();
        
    }
}

