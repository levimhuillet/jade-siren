using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Siren.Inputs
{
    public enum InputSchemeID {
        PlayerDefault,
        ShipHelm,
        ShipCannon
    }

    public static class InputMgr
    {
        private static IInputActionCollection2 m_defaultInputScheme;
        private static IInputActionCollection2 m_currInputScheme;

        public static void SetDefaultScheme(IInputActionCollection2 newInputScheme) {
            m_defaultInputScheme = newInputScheme;
        }

        public static void ActivateInputScheme(IInputActionCollection2 newInputScheme) {
            if (m_currInputScheme != null) {
                m_currInputScheme.Disable();
            }
            m_currInputScheme = newInputScheme;
            m_currInputScheme.Enable();
        }

        public static void DeactivateInputScheme(IInputActionCollection2 toDeactivate) {
            if (m_currInputScheme == toDeactivate) {
                m_currInputScheme.Disable();

                // restore default
                m_currInputScheme = m_defaultInputScheme;
                m_currInputScheme.Enable();
            }
        }
    }
}
