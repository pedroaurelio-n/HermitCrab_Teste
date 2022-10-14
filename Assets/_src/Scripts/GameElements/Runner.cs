using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    [RequireComponent(typeof(RunnerMovement))]
    public class Runner : MonoBehaviour, IDestroyable
    {
        private RunnerMovement _movement;
        private PlayerAnimation _playerAnimation;

        private void Awake()
        {
            _movement = GetComponent<RunnerMovement>();
            _playerAnimation = GetComponentInChildren<PlayerAnimation>();
        }

        public void Destroy()
        {
            _movement.ResetVelocity();
            _playerAnimation.DeathAnimation();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_movement.CurrentVelocity.x <= 0f)
                Destroy();
        }
    }
}
