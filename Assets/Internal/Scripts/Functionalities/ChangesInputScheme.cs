using Siren.Inputs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Siren.Functionalities
{
    public class ChangesInputScheme : MonoBehaviour
    {
        [SerializeField] private InputSchemeID m_inputSchemeID;
        [SerializeField] private bool m_isDefault;

        IInputActionCollection2 m_inputScheme;

        #region External 

        public void Init() {
            m_inputScheme = null;

            switch (m_inputSchemeID) {
                case InputSchemeID.PlayerDefault:
                    m_inputScheme = new PlayerMovement();
                    break;
                case InputSchemeID.ShipHelm:
                    m_inputScheme = new HelmControls();
                    break;
                case InputSchemeID.ShipCannon:
                    m_inputScheme = new CannonControls();
                    break;
                default:
                    break;
            }

            if (m_inputScheme == null) {
                Debug.Log("[InputMgr] New input scheme not found.");
                return;
            }

            if (m_isDefault) {
                InputMgr.SetDefaultScheme(m_inputScheme);
                InputMgr.ActivateInputScheme(m_inputScheme);
            }
        }

        public void ActivateScheme() {
            InputMgr.ActivateInputScheme(m_inputScheme);
        }
        public void DeactivateScheme() {
            InputMgr.DeactivateInputScheme(m_inputScheme);
        }

        #endregion // External

        #region Queries

        public IInputActionCollection2 GetInputScheme() {
            return m_inputScheme;
        }

        #endregion // Queries
    }
}