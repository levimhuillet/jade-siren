using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Functionalities.Affecters
{
    public enum Type
    {
        None,
        Vortex,
        Current
    }

    [RequireComponent(typeof(Collider2D))]
    public class AffectsMovement : MonoBehaviour
    {
        [SerializeField] private Type m_affectType;

        private List<MovementAffectable> m_affectedObjs;

        public delegate void EffectFunc(MovementAffectable toMove);

        public EffectFunc EffectFuncHandler;


        #region Callbacks

        private void Awake() {
            if (m_affectedObjs == null) {
                m_affectedObjs = new List<MovementAffectable>();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            MovementAffectable toMove = collision.gameObject.GetComponent<MovementAffectable>();
            if (toMove == null) { return; }

            if (toMove.IsAffectedBy(m_affectType) && !m_affectedObjs.Contains(toMove)) {
                m_affectedObjs.Add(toMove);
            }
        }

        private void OnCollisionExit2D(Collision2D collision) {
            MovementAffectable toMove = collision.gameObject.GetComponent<MovementAffectable>();
            if (toMove == null) { return; }

            if (m_affectedObjs.Contains(toMove)) {
                m_affectedObjs.Remove(toMove);
            }
        }

        private void FixedUpdate() {
            if (m_affectedObjs == null) { return; }

            for (int i = 0; i < m_affectedObjs.Count; i++) {
                EffectFuncHandler(m_affectedObjs[i]);
            }
        }

        #endregion // Callbacks
    }
}