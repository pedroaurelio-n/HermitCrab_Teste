using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class ShootBullet : MonoBehaviour
    {
        public bool HasShot { get; set; }

        [Header("Settings")]
        [SerializeField] private ShotDirection direction;
        [SerializeField] private float speed;
        [SerializeField] private float fireRate;
        [SerializeField] private bool needInput;
        [SerializeField] private Rigidbody2D bulletPrefab;
        [SerializeField] private Transform shootPos;

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

            _shootTime = 0f;
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
            var bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
            bullet.velocity = _direction * speed;

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
