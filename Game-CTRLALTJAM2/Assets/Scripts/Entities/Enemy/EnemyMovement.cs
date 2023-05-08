using UnityEngine;

namespace Entities.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private Transform _target;
        private Rigidbody2D _rb;
        private float _speed = 0.5f;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _target = GameObject.FindGameObjectWithTag("Player").transform;           
        }

        private void Update()
        {
            EnemyLook(_target.position);
            EnemyMove();
        }

        public void EnemyMove()
        {
            var dir = _target.position - transform.position;

            _rb.velocity = new Vector2(dir.x * _speed, dir.y * _speed);
        }

        private void EnemyLook(Vector3 target)
        {
            Vector2 directionLook = target - transform.position;
            float angle = (Mathf.Atan2(directionLook.y, directionLook.x) * Mathf.Rad2Deg) - 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        }
    }
}