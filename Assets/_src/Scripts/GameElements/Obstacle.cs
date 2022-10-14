using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class Obstacle : MonoBehaviour, IDestroyable
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
