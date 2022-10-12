using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    [RequireComponent(typeof(RunnerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private RunnerMovement _movement;

        private void Awake()
        {
            _movement = GetComponent<RunnerMovement>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _movement.SetJumpInput(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _movement.SetJumpInput(false);
            }
        }
    }
}
