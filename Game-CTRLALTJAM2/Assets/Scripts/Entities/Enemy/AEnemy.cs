using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI.GameManagement;


namespace Entities.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class AEnemy : MonoBehaviour
    {
        [Space]
        [Header("Life Parameters")]
        [SerializeField] protected float maxHealth;
        [SerializeField] protected GameObject healthBar;
        [SerializeField] protected Image filledHealthtBar;
        protected float _currentHealth;

        [Space]
        [Header("Movement Parameters")]
        // _speed fica dentro de cada inimigo.
        protected Transform _target;
        protected Rigidbody2D _rb;

        [Header("Attack Parameters")]
        [SerializeField]protected float _minDistToAttack;
        protected bool _isPlayerInRange = false;
        protected Vector2 _distanceToPlayer;

        [Space]
        [Header("Particle Parameters")]
        [SerializeField] public EnemyParticlePool _particlePrefab;
        [SerializeField] public Transform _bulletSpawn;
        [SerializeField] protected float _fireRate;
        protected EnemyParticleSpawner _particleSpawner;
        protected float timer;

        private void Awake()
        {
            healthBar.gameObject.SetActive(false);
            _currentHealth = maxHealth;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _particleSpawner = GetComponent<EnemyParticleSpawner>();
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        protected virtual void Update()
        {
            LostHealth();
            EnemyLook(_target.position);
            MovementTowardsPlayer();
            VerifyRange();
            AttackBehaviour();
        }

        protected abstract void MovementTowardsPlayer();
        protected abstract void PatrolMovement();
        protected abstract void VerifyRange();
        protected abstract void AttackBehaviour();
        protected abstract void LostHealth();        
        protected abstract void Die();

        protected virtual void HealthBarFiller(float damage)
        {
            _currentHealth -= damage;
            float fillAmountPercentage = _currentHealth / maxHealth;

            filledHealthtBar.fillAmount = Mathf.Lerp(filledHealthtBar.fillAmount, fillAmountPercentage, 1);
        }

        protected virtual void EnemyLook(Vector3 target)
        {
            _distanceToPlayer = target - transform.position;
            float angle = (Mathf.Atan2(_distanceToPlayer.y, _distanceToPlayer.x) * Mathf.Rad2Deg) - 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        } 
    }
}

