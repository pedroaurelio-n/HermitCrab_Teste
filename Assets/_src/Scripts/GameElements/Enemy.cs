using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class Enemy : MonoBehaviour, IDestroyable
    {
        public delegate void EnemyDefeated(int score);
        public static event EnemyDefeated onEnemyDefeated;

        [SerializeField] private int scoreOnDefeat;
        [SerializeField] private ParticleSystem deathParticles;

        private Collider2D _collider;
        private EnemyAnimation _enemyAnimation;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _enemyAnimation = GetComponentInChildren<EnemyAnimation>();
        }

        public void Destroy()
        {
            _collider.enabled = false;
            _enemyAnimation.DeathAnimation();
            onEnemyDefeated?.Invoke(scoreOnDefeat);
            deathParticles.Play();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Runner>(out Runner runner))
            {
                _enemyAnimation.AttackAnimation();
            }
        }

        private void OnEnable()
        {            
            _enemyAnimation.IdleAnimation();
            _collider.enabled = true;
        }
    }
}
