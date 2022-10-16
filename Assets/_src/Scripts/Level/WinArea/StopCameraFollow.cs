using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class StopCameraFollow : MonoBehaviour
    {
        public delegate void StopFollow();
        public static event StopFollow onStopFollow;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerInput>(out PlayerInput playerInput))
            {
                playerInput.enabled = false;
                onStopFollow?.Invoke();
            }
        }
    }
}
