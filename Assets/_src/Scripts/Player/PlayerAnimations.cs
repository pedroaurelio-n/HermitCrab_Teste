using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class PlayerAnimations : MonoBehaviour
    {
        [Header("Animator Params")]
        [SerializeField] private string isGrounded = "IsGrounded";
        [SerializeField] private string shoot = "Shoot";

        private RunnerMovement _movement;
        private ShootBullet _shoot;
        private Animator _animator;

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
    }
}
