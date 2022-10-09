using Siren.Functionalities;
using Siren.Functionalities.Interactables;
using Siren.Projectiles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren
{
    [RequireComponent(typeof(ChangesInputScheme))]
    [RequireComponent(typeof(Interactable))]
    [RequireComponent(typeof(CameraView))]
    public class Cannon : MonoBehaviour
    {
        private Interactable m_interactableComp;
        private CameraView m_camViewComp;
        private ChangesInputScheme m_changesInputComp;

        private CannonControls m_inputControls;

        [SerializeField] private GameObject m_projectilePrefab;
        [SerializeField] private float m_launchSpeed;

        [SerializeField] private Transform m_cannonMouthTransform;

        private void Awake() {
            m_interactableComp = this.GetComponent<Interactable>();
            m_interactableComp.OnInteract += HandleInteract;

            m_camViewComp = this.GetComponent<CameraView>();

            m_changesInputComp = this.GetComponent<ChangesInputScheme>();
            m_changesInputComp.Init();
            m_inputControls = (CannonControls)m_changesInputComp.GetInputScheme();
            AssignControls();
        }

        #region Helpers

        private void AssignControls() {
            m_inputControls.Main.Exit.performed += ctx => HandleExitPerformed();
            m_inputControls.Main.Shoot.performed += ctx => HandleShootPerformed();
        }

        #endregion // Helpers

        #region Handlers

        private void HandleInteract(object sender, EventArgs args) {
            m_changesInputComp.ActivateScheme();
            m_camViewComp.ActivateView();
        }

        private void HandleExitPerformed() {
            m_changesInputComp.DeactivateScheme();
            m_camViewComp.DeactivateView();
        }

        private void HandleShootPerformed() {
            Vector3 launchDir = (m_cannonMouthTransform.position - this.transform.position).normalized;

            Projectile newProjectile = Instantiate(m_projectilePrefab).GetComponent<Projectile>();
            newProjectile.Init(m_cannonMouthTransform.position, m_launchSpeed, launchDir);
            newProjectile.Launch();
        }

        #endregion // Handlers

        #region Temp Debug

        private IEnumerator DeactivateAfter(float time) {
            while (time > 0) {
                time -= Time.deltaTime;
                yield return null;
            }

            m_camViewComp.DeactivateView();
            m_changesInputComp.DeactivateScheme();
            yield return null;
        }

        #endregion // Temp Debug
    }
}