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

        private EnemyAnimation _enemyAnimation;

        private void Awake()
        {
            _enemyAnimation = GetComponentInChildren<EnemyAnimation>();
        }

        public void Destroy()
        {
            _enemyAnimation.DeathAnimation();
            onEnemyDefeated?.Invoke(scoreOnDefeat);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Runner>(out Runner runner))
            {
                _enemyAnimation.AttackAnimation();
            }
        }
    }
}
