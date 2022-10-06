using Siren.Functionalities.Interactable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren
{
    [RequireComponent(typeof(Interactable))]
    public class Cannon : MonoBehaviour
    {
        private Interactable m_interactableComp;

        [SerializeField] private GameObject m_projectilePrefab;
        [SerializeField] private float m_launchSpeed;

        [SerializeField] private Transform m_cannonMouthTransform;

        private void Awake() {
            m_interactableComp = this.GetComponent<Interactable>();

            m_interactableComp.OnInteract += HandleInteract;
        }

        #region Handlers

        private void HandleInteract(object sender, EventArgs args) {
            Vector3 launchDir = (m_cannonMouthTransform.position - this.transform.position).normalized;

            Projectile newProjectile = Instantiate(m_projectilePrefab).GetComponent<Projectile>();
            newProjectile.Init(m_cannonMouthTransform.position, m_launchSpeed, launchDir);
            newProjectile.Launch();
        }

        #endregion // Handlers
    }
}