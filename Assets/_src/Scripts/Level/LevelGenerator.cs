using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class LevelGenerator : MonoBehaviour
    {
        public delegate void CalculateDistanceRemaining(float distanceRemaining);
        public static event CalculateDistanceRemaining onDistanceCalculated;

        [Header("Dependencies")]
        [SerializeField] private GameObject startArea;
        [SerializeField] private GameObject finalArea;
        [SerializeField] private List<GameObject> prefabAreas;

        [Header("Dimensions Settings")]
        [SerializeField] private float cameraOffsetX = 6f;
        [SerializeField] private float areaWidth = 24f;

        [Header("Area Settings")]
        [SerializeField] private int startGenerationCount = 3;
        [SerializeField] private int maxActiveAreas = 5;
        [SerializeField] private int areaRepositionLimit = 10;
        [SerializeField] private int gameEndAreaIndex = 30;

        private List<GameObject> _activeAreas = new List<GameObject>();
        private int _areaPositionIndex;
        private int _totalAreas;

        private void Awake()
        {
            _activeAreas.Add(startArea);

            for (int i = _activeAreas.Count; i < startGenerationCount; i++)
            {
                GenerateNewArea();
            }
        }

        private void Start()
        {
            var distanceRemaining = (gameEndAreaIndex * areaWidth);
            onDistanceCalculated?.Invoke(distanceRemaining);
        }

        private void OnValidate()
        {
            if (maxActiveAreas < 3)
                maxActiveAreas = 3;

            if (areaRepositionLimit < maxActiveAreas)
                areaRepositionLimit = maxActiveAreas;
        }

        private void GenerateNewArea()
        {
            _areaPositionIndex++;
            _totalAreas++;

            var areaPositionX = (_areaPositionIndex * areaWidth);
            var areaPosition = new Vector2(areaPositionX + cameraOffsetX, 0f);

            GameObject newArea;

            if (_totalAreas < gameEndAreaIndex)
            {
                var r = Random.Range(0, prefabAreas.Count);
                newArea = Instantiate(prefabAreas[r], areaPosition, Quaternion.identity, transform);
            }
            else
            {
                newArea = Instantiate(finalArea, areaPosition, Quaternion.identity, transform);
            }

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

            if (_areaPositionIndex >= areaRepositionLimit)
                RepositionAreas();

            GenerateNewArea();
        }

        private void RepositionAreas()
        {
            _areaPositionIndex = 0;

            var areasBehindPlayer = maxActiveAreas - 2;
            var resetIndex = -areasBehindPlayer;

            for (int i = 0; i < _activeAreas.Count; i++)
            {
                var areaPositionX = (resetIndex * areaWidth);
                _activeAreas[i].transform.position = new Vector2(areaPositionX + cameraOffsetX, 0f);
                resetIndex++;
            }
        }

        private void OnEnable() => CheckForNewAreaStart.onNewAreaStart += DestroyOldestArea;
        private void OnDisable() => CheckForNewAreaStart.onNewAreaStart -= DestroyOldestArea;
    }
}
