using Siren;
using Siren.Functionalities.Interactables;
using Siren.Functionalities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siren.Projectiles;
using System;
using UnityEngine.InputSystem;

namespace Siren
{
    [RequireComponent(typeof(ChangesInputScheme))]
    [RequireComponent(typeof(Interactable))]
    [RequireComponent(typeof(CameraView))]
    public class Helm : MonoBehaviour
    {
        private Interactable m_interactableComp;
        private CameraView m_camViewComp;
        private ChangesInputScheme m_changesInputComp;

        private HelmControls m_inputControls;
        private bool m_steerHeld;

        [SerializeField] private Ship m_ship;
        [SerializeField] private float m_rotateSpeed;


        private void Awake() {
            m_interactableComp = this.GetComponent<Interactable>();
            m_interactableComp.OnInteract += HandleInteract;

            m_camViewComp = this.GetComponent<CameraView>();

            m_changesInputComp = this.GetComponent<ChangesInputScheme>();
            m_changesInputComp.Init();
            m_inputControls = (HelmControls)m_changesInputComp.GetInputScheme();
            AssignControls();
        }

        private void FixedUpdate() {
            SteerShip();
        }

        #region Helpers

        private void AssignControls() {
            m_inputControls.Main.Exit.performed += ctx => HandleExitPerformed();
            m_inputControls.Main.Steer.performed += ctx => HandleSteerPerformed(ctx.ReadValue<Vector2>());
            m_inputControls.Main.Steer.canceled += ctx => HandleSteerCanceled();
            m_inputControls.Main.ModifySails.performed += ctx => HandleModifySailsPerformed(ctx.ReadValue<Vector2>());
        }

        private void SteerShip() {
            if (m_steerHeld) {
                Vector2 steerVector = m_inputControls.Main.Steer.ReadValue<Vector2>();
                if (steerVector.x > 0) {
                    // rotate right
                    RotateShip(-m_rotateSpeed);
                }
                else if (steerVector.x < 0) {
                    // rotate left
                    RotateShip(m_rotateSpeed);
                }
            }
        }

        private void RotateShip(float rotateSpeed) {
            Vector3 angles = m_ship.transform.rotation.eulerAngles;
            angles.z = angles.z + rotateSpeed * (m_ship.GetNumSailsUnfurled() + 1) * Time.deltaTime;
            m_ship.transform.rotation = Quaternion.Euler(angles);
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

        private void HandleSteerPerformed(Vector2 steerVector) {
            m_steerHeld = true;
        }

        private void HandleSteerCanceled() {
            m_steerHeld = false;
        }


        private void HandleModifySailsPerformed(Vector2 modifyVector) {
            if (modifyVector.y > 0) {
                // try unfurl sail
                m_ship.TryUnfurlSail();
            }
            else if (modifyVector.y < 0){
                // try furl sail
                m_ship.TryFurlSail();
            }
        }

        #endregion // Handlers
    }
}
