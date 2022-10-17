using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, IPoolable
    {
        private Transform _originTransform;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Initialize(Transform origin, Transform levelSpace, Vector3 position, Vector2 speed)
        {
            _originTransform = origin;
            transform.SetPositionAndRotation(position, Quaternion.identity);
            transform.SetParent(levelSpace);
            _rigidbody.velocity = speed;
        }

        public void ReleaseFromPool()
        {
            if (!gameObject.activeInHierarchy)
                return;
            
            transform.SetParent(_originTransform);
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            ReleaseFromPool();
        }
    }
}
