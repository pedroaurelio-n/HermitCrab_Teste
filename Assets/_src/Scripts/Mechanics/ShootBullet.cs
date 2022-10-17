using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class ShootBullet : MonoBehaviour
    {
        public bool HasShot { get; set; }

        [SerializeField] private int initialPoolCount;

        [Header("Settings")]
        [SerializeField] private ShotDirection direction;
        [SerializeField] private float speed;
        [SerializeField] private float fireRate;
        [SerializeField] private bool needInput;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform shootPos;

        private List<Bullet> _bulletPool;

        private bool _shootInput;
        private float _shootTime;
        private Vector2 _direction;

        private void Awake()
        {
            switch (direction)
            {
                case ShotDirection.Right: _direction = Vector2.right; break;
                case ShotDirection.Left: _direction = Vector2.left; break;
            }

            InitializePool();
        }

        private void InitializePool()
        {
            _bulletPool = new List<Bullet>();

            for (int i = 0; i < initialPoolCount; i++)
            {
                var bullet = CreateNewBullet();
                _bulletPool.Add(bullet);
                bullet.gameObject.SetActive(false);
            }
        }

        private Bullet CreateNewBullet()
        {
            var bullet = Instantiate(bulletPrefab, transform);
            // Debug.Log($"Bullet Created");
            return bullet;
        }

        private Bullet GetBulletFromPool()
        {
            Bullet bullet;

            for (int i = 0; i < _bulletPool.Count; i++)
            {
                bullet = _bulletPool[i];
                if (!bullet.gameObject.activeInHierarchy)
                {
                    bullet.gameObject.SetActive(true);
                    // Debug.Log($"Bullet Pooled");
                    return bullet;
                }
            }

            bullet = CreateNewBullet();
            return bullet;
        }

        private void FixedUpdate()
        {
            if (_shootTime > 0)
            {
                _shootTime -= Time.deltaTime;
                return;
            }

            if (!needInput)
            {
                Shoot();
                return;
            }

            if (_shootInput)
                Shoot();
        }

        public void Shoot()
        {
            var bullet = GetBulletFromPool();
            bullet.Initialize(transform, transform.parent, shootPos.position, _direction * speed);

            HasShot = true;
            _shootTime = fireRate;
        }

        public void SetShootInput(bool value) => _shootInput = value;

        enum ShotDirection
        {
            Right,
            Left
        }
    }
}
