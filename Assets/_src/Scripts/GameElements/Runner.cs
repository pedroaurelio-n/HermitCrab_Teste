using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    [RequireComponent(typeof(RunnerMovement))]
    public class Runner : MonoBehaviour, IDestroyable
    {
        public delegate void RunnerDeath();
        public static event RunnerDeath onRunnerDeath;

        [SerializeField] private ParticleSystem jumpParticles;

        private RunnerMovement _movement;
        private ShootBullet _shoot;
        private RunnerAnimation _runnerAnimation;

        private bool _isAlive;
        private bool _hasPlayedParticles;

        private void Awake()
        {
            _movement = GetComponent<RunnerMovement>();
            _shoot = GetComponent<ShootBullet>();
            _runnerAnimation = GetComponentInChildren<RunnerAnimation>();

            _isAlive = true;
        }

        private void Update()
        {
            if (_movement.IsGrounded)
            {
                _hasPlayedParticles = false;
            }

            if (_movement.HasJumped && !_hasPlayedParticles)
            {
                jumpParticles.Play();
                _hasPlayedParticles = true;
            }
        }

        public void Destroy()
        {
            if (!_isAlive)
                return;

            _isAlive = false;
            _movement.ResetVelocity();
            _movement.enabled = false;
            _shoot.enabled = false;
            _runnerAnimation.DeathAnimation();
            onRunnerDeath?.Invoke();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_movement.CurrentVelocity.x <= 0.01f)
                Destroy();
        }
    }
}
