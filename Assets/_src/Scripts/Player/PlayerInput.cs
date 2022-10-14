using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    [RequireComponent(typeof(RunnerMovement))]
    [RequireComponent(typeof(ShootBullet))]
    public class PlayerInput : MonoBehaviour
    {
        private RunnerMovement _movement;
        private ShootBullet _shoot;

        private void Awake()
        {
            _movement = GetComponent<RunnerMovement>();
            _shoot = GetComponent<ShootBullet>();
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

            if (Input.GetMouseButtonDown(1))
            {
                _shoot.SetShootInput(true);
            }

            if (Input.GetMouseButtonUp(1))
            {
                _shoot.SetShootInput(false);
            }
        }
    }
}
