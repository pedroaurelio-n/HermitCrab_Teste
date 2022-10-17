using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class EnemyAnimation : MonoBehaviour
    {
        [Header("Animator Params")]
        [SerializeField] private string isAlive = "IsAlive";
        [SerializeField] private string attack = "Attack";

        private Animator _animator;

        private bool _isDead;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            IdleAnimation();
        }
        
        public void IdleAnimation()
        {
            _animator?.SetBool(isAlive, true);
            _isDead = false;
        }

        public void AttackAnimation()
        {
            _animator?.SetTrigger(attack);
        }

        public void DeathAnimation()
        {
            if (_isDead)
                return;
            
            _animator?.SetBool(isAlive, false);
            _isDead = true;
        }
    }
}
