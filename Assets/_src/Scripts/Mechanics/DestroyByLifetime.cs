using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class DestroyByLifetime : MonoBehaviour
    {
        [SerializeField] private float lifeTime;

        private void Awake()
        {
            Destroy(gameObject, lifeTime);
        }
    }
}
