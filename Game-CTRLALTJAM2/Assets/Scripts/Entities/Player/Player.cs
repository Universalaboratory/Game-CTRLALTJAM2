using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UI.GameManagement;

namespace Entities.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Player Normal Movements Parameters")]
        [SerializeField] private float _playerSpeed;

        [Header("Player Dash Parameters")]
        [SerializeField] private float _dashSpeed;
        [SerializeField] private float _dashCoolDownTimeSeconds;
        [SerializeField] private bool _isDashing;
        [SerializeField] private bool _canDash = true;
        private float _dashTotalDistance = 0.2f;
        private float _timer;
        private bool _dashInput = false;

        private Coroutine _dashCoroutine;

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
            _input.Player.Dash.canceled += OnDashCanceled;

            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Player.Dash.started -= OnDash;
            _input.Player.Dash.canceled -= OnDashCanceled;
        }

        private void Update()
        {
            if (GameManager.Instance._state != GameState.GAMEPLAY) return;

            GetPlayerMovement();
            LookAtMouse();

            if (!_canDash)         
                DashCoolDown();
        }

        private void FixedUpdate()
        {
            if (GameManager.Instance._state != GameState.GAMEPLAY)
            {
                _rb.constraints = RigidbodyConstraints2D.FreezeAll;
                return;
            }

            MovePlayer();

            if (_dashInput && _canDash)
                Dash();
        }

        private void GetPlayerMovement() => _movement = _input.Player.Movement.ReadValue<Vector2>().normalized;

        private void OnDash(InputAction.CallbackContext context) => _dashInput = true;
        private void OnDashCanceled(InputAction.CallbackContext context) => _dashInput = false;

        private void MovePlayer()
        {
            if (_isDashing) return;

            _rb.velocity = new Vector2(_movement.x * _playerSpeed, _movement.y * _playerSpeed);
        }

        private void Dash()
        {
            _canDash = false;
            _isDashing = true;
            GameplayEvents.Dash(_dashCoolDownTimeSeconds);

            StartCoroutine(DashBehaviour());
        }

        private void DashCoolDown()
        {
            _timer += Time.deltaTime;
            if (_timer >= _dashCoolDownTimeSeconds)
            {
                _canDash = true;
                Debug.LogWarning(_canDash);
                _timer = 0;
                return;
            }
        }

        private IEnumerator DashBehaviour()
        {
            Debug.LogWarning("Come�ou Dash");

            _rb.velocity = Vector2.zero;

            var dashForce = new Vector2(_movement.x * _dashSpeed, _movement.y * _dashSpeed);
            _rb.AddForce(dashForce, ForceMode2D.Impulse);

            yield return new WaitForSeconds(_dashTotalDistance);
            _isDashing = false;

            Debug.LogWarning("Terminou Dash");
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