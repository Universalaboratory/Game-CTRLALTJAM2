using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Entities.Player 
{
    public class PlayerShootBehaviour : MonoBehaviour
    {
        [SerializeField] public ParticlePool _particlePrefab;
        [SerializeField] public Transform _bulletSpawn;
        [SerializeField] private float _fireRate;

        private float timer;
        private bool _isShooting;

        private ParticleSpawner _particleSpawner;
        private InputControl _input;


        private void Awake()
        {
            _input = new InputControl();
        }

        private void Start()
        {
            _particleSpawner = GetComponent<ParticleSpawner>();
        }

        private void OnEnable()
        {
            _input.Player.Shoot.performed += OnShootThisFrame;
            _input.Player.Shoot.canceled += OnStopShooting;
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Player.Shoot.performed -= OnShootThisFrame;
            _input.Player.Shoot.canceled -= OnStopShooting;
        }

        void Update()
        {
            ShootBehaviour();
        }

        private void OnShootThisFrame(InputAction.CallbackContext context) => _isShooting = true;

        private void OnStopShooting(InputAction.CallbackContext context) => _isShooting = false;

        private void ShootBehaviour()
        {
            if (!_isShooting) return;

            timer += Time.deltaTime;

            float nextTimeToFire = 1 / _fireRate;

            if (timer >= nextTimeToFire)
            {
                _particleSpawner._pool.Get();
                timer = 0;
            }
        }
    }

}

