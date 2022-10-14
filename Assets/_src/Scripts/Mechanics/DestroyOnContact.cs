using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class DestroyOnContact : MonoBehaviour
    {
        [SerializeField] private LayerMask contactLayers;

        private void OnCollisionEnter2D(Collision2D other)
        {
            var otherLayer = other.gameObject.layer;

            if ((1 << otherLayer & contactLayers) != 0) 
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherLayer = other.gameObject.layer;

            if ((1 << otherLayer & contactLayers) != 0) 
                Destroy(gameObject);
        }
    }
}
