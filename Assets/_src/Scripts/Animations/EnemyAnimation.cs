using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class EnemyAnimation : MonoBehaviour
    {
        [Header("Animator Params")]
        [SerializeField] private string attack = "Attack";
        [SerializeField] private string die = "Die";

        private Animator _animator;

        private bool _isDead;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void AttackAnimation()
        {
            _animator.SetTrigger(attack);
        }

        public void DeathAnimation()
        {
            if (_isDead)
                return;
            
            _animator.SetTrigger(die);
            _isDead = true;
        }
    }
}
