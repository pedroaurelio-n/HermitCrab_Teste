using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace PedroAurelio.HermitCrab
{
    public class CinemachineCamera : MonoBehaviour
    {
        private CinemachineVirtualCamera _cinemachineCamera;

        private void Awake() => _cinemachineCamera = GetComponent<CinemachineVirtualCamera>();

        private void StopFollow() => _cinemachineCamera.m_Follow = null;

        private void OnEnable() => StopCameraAndInputs.onStopCameraFollow += StopFollow;
        private void OnDisable() => StopCameraAndInputs.onStopCameraFollow -= StopFollow;
    }
}
