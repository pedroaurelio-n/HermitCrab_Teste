using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject startArea;
        [SerializeField] private GameObject prefabArea;
        [SerializeField] private float cameraOffsetX = 6f;
        [SerializeField] private float areaWidth = 24f;
        [SerializeField] private int startGenerationCount = 3;
        [SerializeField] private int maxActiveAreas = 5;

        private List<GameObject> _activeAreas = new List<GameObject>();
        private int _areaIndex;

        private void Awake()
        {
            _activeAreas.Add(startArea);

            for (int i = _activeAreas.Count; i < startGenerationCount; i++)
            {
                GenerateNewArea();
            }
        }

        private void GenerateNewArea()
        {            
            _areaIndex++;

            var areaPositionX = (_areaIndex * areaWidth);

            var areaPosition = new Vector2(areaPositionX + cameraOffsetX, 0f);
            var newArea = Instantiate(prefabArea, areaPosition, Quaternion.identity, transform);

            _activeAreas.Add(newArea);
        }

        private void DestroyOldestArea()
        {
            if (_activeAreas.Count >= maxActiveAreas)
            {
                var oldestArea = _activeAreas[0];
                Destroy(oldestArea);
                _activeAreas.RemoveAt(0);
            }

            GenerateNewArea();
        }

        private void OnEnable()
        {
            CheckForRunnerExit.onRunnerExitedArea += DestroyOldestArea;
        }

        private void OnDisable()
        {
            CheckForRunnerExit.onRunnerExitedArea -= DestroyOldestArea;
        }
    }
}
