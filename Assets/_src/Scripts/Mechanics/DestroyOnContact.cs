using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class DestroyOnContact : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private LayerMask contactLayers;

        private void CheckForContact(GameObject other)
        {
            var otherLayer = other.layer;
            var otherIsInContactLayer = (1 << otherLayer & contactLayers) != 0;

            if (otherIsInContactLayer) 
            {
                if (TryGetComponent<IPoolable>(out IPoolable poolable))
                    poolable.ReleaseFromPool();
                else
                    gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter2D(Collision2D other) => CheckForContact(other.gameObject);
        private void OnTriggerEnter2D(Collider2D other) => CheckForContact(other.gameObject);
    }
}
