using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PedroAurelio.HermitCrab
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private ShowScore gameScore;

        [SerializeField] private GameObject winScreen;
        [SerializeField] private TextMeshProUGUI winScore;
        [SerializeField] private GameObject lossScreen;
        [SerializeField] private TextMeshProUGUI lossScore;

        private void ShowWinScreen()
        {
            winScreen.SetActive(true);
            winScore.text = gameScore.CurrentScore.ToString();
        }

        private void ShowLossScreen()
        {
            lossScreen.SetActive(true);
            var halfScore = Mathf.CeilToInt(gameScore.CurrentScore * 0.5f);
            lossScore.text = halfScore.ToString();
        }

        private void OnEnable()
        {
            TriggerGameWin.onGameWin += ShowWinScreen;
            Runner.onRunnerDeath += ShowLossScreen;
        }

        private void OnDisable()
        {
            TriggerGameWin.onGameWin -= ShowWinScreen;
            Runner.onRunnerDeath -= ShowLossScreen;
        }
    }
}
