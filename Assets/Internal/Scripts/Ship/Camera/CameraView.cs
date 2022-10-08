using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera m_vcam;
        [SerializeField] private float m_baseXOffset;
        [SerializeField] private float m_zoomOffsetFactor;

        [SerializeField] private bool m_useLocalRotation;

        private float m_currXOffset;
        private CinemachineFramingTransposer m_camTransposer;

        private void Start() {
            if (m_vcam != null) {
                m_camTransposer = m_vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
                m_camTransposer.m_TrackedObjectOffset.x = m_baseXOffset;
            }
        }

        private void Update() {
            if (m_vcam != null && m_vcam.enabled) {
                m_camTransposer.m_TrackedObjectOffset.x = m_baseXOffset * m_zoomOffsetFactor * m_vcam.m_Lens.OrthographicSize;
                if (m_useLocalRotation) {
                    Vector3 angles = this.transform.rotation.eulerAngles;
                    m_vcam.transform.rotation = Quaternion.Euler(angles);
                }
            }
        }

        #region Queries

        public bool IsCamActive() {
            return m_vcam.enabled;
        }

        #endregion // Queries

        #region External

        public void ActivateView() {
            m_vcam.enabled = true;
        }

        public void DeactivateView() {
            m_vcam.enabled = false;
        }

        #endregion // External
    }
}
