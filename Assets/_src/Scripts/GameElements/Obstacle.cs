using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class Obstacle : MonoBehaviour, IDestroyable
    {
        [SerializeField] private ParticleSystem _deathParticles;

        private Collider2D _collider;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void Destroy()
        {
            _collider.enabled = false;
            _spriteRenderer.enabled = false;
            _deathParticles.Play();
        }

        private void OnEnable()
        {
            _collider.enabled = true;
            _spriteRenderer.enabled = true;
        }
    }
}
