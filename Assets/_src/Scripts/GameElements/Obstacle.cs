using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class Obstacle : MonoBehaviour, IKillable
    {
        [Header("Dependencies")]
        [SerializeField] private ParticleSystem deathParticles;

        private Collider2D _collider;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void Death()
        {
            _collider.enabled = false;
            _spriteRenderer.enabled = false;
            deathParticles.Play();
            CinemachineCamera.ShakeCamera(0.4f, 4f, 20);
        }

        private void OnEnable()
        {
            _collider.enabled = true;
            _spriteRenderer.enabled = true;
        }
    }
}
