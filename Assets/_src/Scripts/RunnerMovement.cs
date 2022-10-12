using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RunnerMovement : MonoBehaviour
    {
        [Header("General Settings")]
        [SerializeField] private Vector2 initialVelocity = new Vector2(3f, 0f);
        [SerializeField] private float maxYPosition = 12f;

        [Header("Jump Settings")]
        [SerializeField] private Transform groundCheckPoint;
        [SerializeField] private float groundCheckRadius = 0.5f;
        [SerializeField] private LayerMask groundCheckLayer = -1;
        [SerializeField] private float jumpHeight = 5f;

        [Header("Airborne Settings")]
        [SerializeField] private float _coyoteTimeThreshold = 0.25f;
        [SerializeField] private float _preJumpThreshold = 0.25f;
        [SerializeField, Range(0f, 3f)] private float fallMultiplier = 0.5f;
        [SerializeField, Range(0f, 3f)] private float lowJumpMultiplier = 0.5f;

        private Rigidbody2D _rigidbody;

        private bool _jumpInput;
        private bool _isGrounded;
        private float _jumpForce;
        private float _coyoteTimeBuffer;
        private float _preJumpBuffer;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _rigidbody.velocity = initialVelocity;

            _jumpForce = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
        }

        private void Update()
        {
            CheckGroundedStatus();
            LimitPositionY();
        }

        private void CheckGroundedStatus()
        {
            if (_preJumpBuffer > 0f && _coyoteTimeBuffer > 0f)
            {
                Jump();
                return;
            }
            
            var overlapCollider = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundCheckLayer);
            _isGrounded = overlapCollider != null;

            _coyoteTimeBuffer = _isGrounded ? _coyoteTimeThreshold : _coyoteTimeBuffer -= Time.deltaTime;
            _preJumpBuffer -= Time.deltaTime;
        }

        private void LimitPositionY()
        {
            if (transform.position.y <= maxYPosition)
                return;

            ResetVelocityY();

            var clampedPosition = new Vector2(transform.position.x, maxYPosition);
            transform.position = clampedPosition;
        }

        private void Jump()
        {
            ResetVelocityY();

            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            _coyoteTimeBuffer = 0f;
            _preJumpBuffer = 0f;
        }

        private void ResetVelocityY() => _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);

        private void FixedUpdate()
        {
            ApplyFallingForces();
        }

        private void ApplyFallingForces()
        {
            if (_isGrounded)
                return;
            
            if (!_jumpInput && _rigidbody.velocity.y > 0)
                _rigidbody.AddForce(lowJumpMultiplier * _rigidbody.velocity.y * Vector2.down);
            else if (_rigidbody.velocity.y < 0)
                _rigidbody.AddForce(fallMultiplier * _rigidbody.velocity.y * Vector2.up);
        }

        public void SetJumpInput(bool value)
        {
            _jumpInput = value;

            if (_jumpInput)
                _preJumpBuffer = _preJumpThreshold;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
        }
    }
}
