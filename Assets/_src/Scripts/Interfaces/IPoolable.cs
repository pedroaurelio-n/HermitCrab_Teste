using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public interface IPoolable
    {
        public void ReleaseFromPool();
    }
}
