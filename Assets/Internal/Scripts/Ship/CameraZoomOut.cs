using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren
{
    public class CameraZoomOut : MonoBehaviour
    {
        [SerializeField] private float m_zoomSpeed;

        private CinemachineVirtualCamera m_cam;

        private void Awake() {
            m_cam = this.GetComponent<CinemachineVirtualCamera>();
        }

        private void Update() {
            m_cam.m_Lens.OrthographicSize += m_zoomSpeed * Time.deltaTime;
        }
    }
}
