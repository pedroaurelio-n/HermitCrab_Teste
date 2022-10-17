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

        private float _screenHalfWidth;

        private void Awake()
        {
            _movement = GetComponent<RunnerMovement>();
            _shoot = GetComponent<ShootBullet>();

            _screenHalfWidth = Screen.width * 0.5f;
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.position.x <= _screenHalfWidth)
                    {
                        if (touch.phase == TouchPhase.Began)
                            _movement.SetJumpInput(true);
                        else if (touch.phase == TouchPhase.Ended)
                            _movement.SetJumpInput(false);
                    }
                    else
                    {
                        if (touch.phase == TouchPhase.Began)
                            _shoot.SetShootInput(true);
                        else if (touch.phase == TouchPhase.Ended)
                            _shoot.SetShootInput(false);
                    }
                }
            }

            #if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                _shoot.SetShootInput(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _shoot.SetShootInput(false);
            }

            if (Input.GetMouseButtonDown(1))
            {
                _movement.SetJumpInput(true);
            }

            if (Input.GetMouseButtonUp(1))
            {
                _movement.SetJumpInput(false);
            }
            #endif
        }
    }
}
