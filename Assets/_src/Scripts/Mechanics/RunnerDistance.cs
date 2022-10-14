using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    [RequireComponent(typeof(RunnerMovement))]
    public class RunnerDistance : MonoBehaviour
    {
        public static float CurrentDistance { get; private set; }

        private RunnerMovement _movement;

        private void Awake()
        {
            _movement = GetComponent<RunnerMovement>();
            CurrentDistance = 0f;
        }

        private void Update()
        {
            var distanceTravelled = _movement.CurrentVelocity.x * Time.deltaTime;
            CurrentDistance += distanceTravelled;
        }      
    }
}
