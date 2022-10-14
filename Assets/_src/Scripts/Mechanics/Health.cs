using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        private float _currentHealth;

        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void ModifyHealth(float value)
        {
            _currentHealth += value;

            if (_currentHealth <= 0)
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
