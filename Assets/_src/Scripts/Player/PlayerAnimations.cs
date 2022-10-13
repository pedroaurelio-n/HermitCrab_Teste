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
        private Animator _animator;

        private void Awake()
        {
            _movement = transform.parent.GetComponent<RunnerMovement>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetBool(isGrounded, _movement.IsGrounded);

            if (Input.GetMouseButtonDown(1))
                _animator.SetTrigger(shoot);
        }
    }
}
