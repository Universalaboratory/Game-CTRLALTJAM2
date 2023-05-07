using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Entities.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Player Normal Movements Parameters")]
        [SerializeField] private float _playerSpeed;

        [Header("Player Dash Parameters")]   
        [SerializeField] private float _dashSpeed;
        [SerializeField] private float _dashTotalTimeSeconds;
        [SerializeField] private float _dashCoolDownTimeSeconds;
        private bool _isDashing;
        private bool _canDash = true;

        private Vector2 _movement;

        private Rigidbody2D _rb;
        private InputControl _input;
        private Camera mainCamera;

        private void Awake()
        {
            _input = new InputControl();
            _rb = GetComponent<Rigidbody2D>();
            mainCamera = Camera.main;

        }

        private void OnEnable()
        {
            _input.Player.Dash.started += OnDash;
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Player.Dash.started -= OnDash;
        }

        private void Update()
        {
            GetPlayerMovement();
            LookAtMouse();
        }

        private void FixedUpdate()
        {
            MovePlayer();
            Dash();
        }

        private void GetPlayerMovement() => _movement = _input.Player.Movement.ReadValue<Vector2>().normalized;

        private void OnDash(InputAction.CallbackContext context) => _isDashing = true;

        private void MovePlayer()
        {
            if (_isDashing) return;

            _rb.velocity = new Vector2(_movement.x * _playerSpeed, _movement.y * _playerSpeed);
        }

        private void Dash()
        {
            if (_isDashing && _canDash) StartCoroutine(DashBehaviour());
        }

        private IEnumerator DashBehaviour()
        {
            _rb.velocity = new Vector2(_movement.x * _dashSpeed, _movement.y * _dashSpeed);

            yield return new WaitForSeconds(_dashTotalTimeSeconds);
            _isDashing = false;
            _canDash = false;

            _rb.velocity = new Vector2(_movement.x * _playerSpeed, _movement.y * _playerSpeed);

            yield return new WaitForSeconds(_dashCoolDownTimeSeconds);

            _canDash = true;
        }

        private void LookAtMouse()
        {
            Vector2 dir = mainCamera.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        }
    }
}