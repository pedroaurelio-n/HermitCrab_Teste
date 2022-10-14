using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.HermitCrab
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject startArea;
        [SerializeField] private List<GameObject> prefabAreas;
        [SerializeField] private float cameraOffsetX = 6f;
        [SerializeField] private float areaWidth = 24f;
        [SerializeField] private int startGenerationCount = 3;
        [SerializeField] private int maxActiveAreas = 5;
        [SerializeField] private int limitArea = 10;

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

            var r = Random.Range(0, prefabAreas.Count);
            var newArea = Instantiate(prefabAreas[r], areaPosition, Quaternion.identity, transform);

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

            if (_areaIndex >= limitArea)
                RepositionAreas();

            GenerateNewArea();
        }

        private void RepositionAreas()
        {
            _areaIndex = 0;
            var resetIndex = -1;

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
