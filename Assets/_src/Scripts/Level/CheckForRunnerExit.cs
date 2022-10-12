using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class CheckForRunnerExit : MonoBehaviour
    {
        public delegate void RunnerExitedArea();
        public static event RunnerExitedArea onRunnerExitedArea;

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<RunnerMovement>(out RunnerMovement runner))
            {
                onRunnerExitedArea?.Invoke();
            }
        }
    }
}
