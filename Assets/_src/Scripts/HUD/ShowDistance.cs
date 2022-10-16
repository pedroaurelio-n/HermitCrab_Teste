using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PedroAurelio.HermitCrab
{
    public class ShowDistance : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI distanceNumber;

        private void Update()
        {
            if (RunnerDistance.CurrentDistance > 0f)
                distanceNumber.text = RunnerDistance.CurrentDistance.ToString("0");
            else
                distanceNumber.text = "0";
        }
    }
}
