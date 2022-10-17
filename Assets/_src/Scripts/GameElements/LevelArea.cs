using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class LevelArea : MonoBehaviour, IPoolable
    {
        public int Id { get; private set; }

        public void SetID(int id) => Id = id;

        public void Initialize(Vector3 position)
        {
            transform.SetPositionAndRotation(position, Quaternion.identity);
        }
        
        public void ReleaseFromPool()
        {
            gameObject.SetActive(false);
        }
    }
}
