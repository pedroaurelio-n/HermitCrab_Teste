using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class PlayerAnimation : MonoBehaviour
    {
        [Header("Animator Params")]
        [SerializeField] private string isGrounded = "IsGrounded";
        [SerializeField] private string shoot = "Shoot";
        [SerializeField] private string die = "Die";

        private RunnerMovement _movement;
        private ShootBullet _shoot;
        private Animator _animator;

        private bool _isDead;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            
            _movement = transform.parent.GetComponent<RunnerMovement>();
            _shoot = transform.parent.GetComponent<ShootBullet>();
        }

        private void Update()
        {
            _animator.SetBool(isGrounded, _movement.IsGrounded);

            if (_shoot.HasShot)
            {
                _animator.SetTrigger(shoot);
                _shoot.HasShot = false;
            }
        }

        public void DeathAnimation()
        {
            if (_isDead)
                return;
            
            _animator.SetTrigger(die);
            _isDead = true;

            _movement.enabled = false;
            _shoot.enabled = false;
        }
    }
}