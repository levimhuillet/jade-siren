using Siren.Functionalities.Interactables;
using Siren.Projectiles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren
{
    [RequireComponent(typeof(Interactable))]
    [RequireComponent(typeof(CameraView))]
    public class Cannon : MonoBehaviour
    {
        private Interactable m_interactableComp;
        private CameraView m_camViewComp;

        [SerializeField] private GameObject m_projectilePrefab;
        [SerializeField] private float m_launchSpeed;

        [SerializeField] private Transform m_cannonMouthTransform;

        private void Awake() {
            m_interactableComp = this.GetComponent<Interactable>();
            m_interactableComp.OnInteract += HandleInteract;

            m_camViewComp = this.GetComponent<CameraView>();
        }

        #region Handlers

        private void HandleInteract(object sender, EventArgs args) {
            if (m_camViewComp.IsCamActive()) {
                Vector3 launchDir = (m_cannonMouthTransform.position - this.transform.position).normalized;

                Projectile newProjectile = Instantiate(m_projectilePrefab).GetComponent<Projectile>();
                newProjectile.Init(m_cannonMouthTransform.position, m_launchSpeed, launchDir);
                newProjectile.Launch();
            }
            else {
                m_camViewComp.ActivateView();
                StartCoroutine(DeactivateAfter(6));
            }
        }

        #endregion // Handlers

        #region Temp Debug

        private IEnumerator DeactivateAfter(float time) {
            while (time > 0) {
                time -= Time.deltaTime;
                yield return null;
            }

            m_camViewComp.DeactivateView();
            yield return null;
        }

        #endregion // Temp Debug
    }
}