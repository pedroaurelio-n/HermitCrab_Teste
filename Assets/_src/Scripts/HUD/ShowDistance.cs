using UnityEngine;
using TMPro;

namespace PedroAurelio.HermitCrab
{
    public class ShowDistance : MonoBehaviour
    {
        [Header("Dependencies")]
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
