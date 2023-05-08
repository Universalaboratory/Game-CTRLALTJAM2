using UnityEngine;

namespace Entities.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private GameObject _target;
        private Rigidbody2D rb;
        private float _speed = 0.5f;

        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player");
            

            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            EnemyLook(_target.GetComponent<Transform>().position);
            EnemyMove();
        }

        public void EnemyMove()
        {
            //transform.Translate((_targetPos.position - transform.position) * Time.deltaTime * _speed, Space.World);
        }

        private void EnemyLook(Vector2 target)
        {
            Vector2 directionLook = (target - (Vector2) transform.position).normalized;
            float angle = Mathf.Atan2(directionLook.y, directionLook.x) * Mathf.Deg2Rad;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle));
        }
    }
}