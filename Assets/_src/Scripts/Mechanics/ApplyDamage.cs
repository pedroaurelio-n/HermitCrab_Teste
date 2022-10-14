using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class ApplyDamage : MonoBehaviour
    {
        [SerializeField] private float damage;

        private void OnValidate()
        {
            if (damage < 0)
                damage = 0;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Health>(out Health otherHealth))
            {
                otherHealth.ModifyHealth(-damage);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Health>(out Health otherHealth))
            {
                otherHealth.ModifyHealth(-damage);
            }
        }
    }
}
