using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        private IDestroyable _destroyable;

        private float _currentHealth;

        private void Awake()
        {
            if (!TryGetComponent<IDestroyable>(out _destroyable))
                Debug.LogError($"Health component needs reference to an IDestroyable.");
            
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
            _destroyable.Destroy();
        }
    }
}
