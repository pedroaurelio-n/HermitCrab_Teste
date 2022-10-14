using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class DestroyOnContact : MonoBehaviour
    {
        [SerializeField] private LayerMask contactLayers;

        private void CheckForContact(GameObject other)
        {
            var otherLayer = other.layer;

            if ((1 << otherLayer & contactLayers) != 0) 
                Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            CheckForContact(other.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CheckForContact(other.gameObject);
        }
    }
}
