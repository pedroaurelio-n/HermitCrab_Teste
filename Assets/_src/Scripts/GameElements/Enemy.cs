using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class Enemy : MonoBehaviour, IKillable
    {
        public delegate void EnemyDefeated(int score);
        public static event EnemyDefeated onEnemyDefeated;

        [Header("Dependencies")]
        [SerializeField] private ParticleSystem deathParticles;

        [Header("Settings")]
        [SerializeField] private int scoreOnDefeat;

        private Collider2D _collider;
        private EnemyAnimation _enemyAnimation;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _enemyAnimation = GetComponentInChildren<EnemyAnimation>();
        }

        public void Death()
        {
            _collider.enabled = false;
            _enemyAnimation.DeathAnimation();
            onEnemyDefeated?.Invoke(scoreOnDefeat);
            deathParticles.Play();
            CinemachineCamera.ShakeCamera(0.2f, 1f, 10);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
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
