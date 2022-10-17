using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class HideTutorial : MonoBehaviour
    {
        [SerializeField] private List<GameObject> hudElements;
        [SerializeField] private float hideAfterTime;

        private void Awake()
        {
            SetHudElements(false);
            StartCoroutine(Hide());
        }

        private void SetHudElements(bool value)
        {
            foreach (GameObject element in hudElements)
                element.SetActive(value);
        }

        private IEnumerator Hide()
        {
            yield return new WaitForSeconds(hideAfterTime);

            SetHudElements(true);
            gameObject.SetActive(false);
        }
    }
}
