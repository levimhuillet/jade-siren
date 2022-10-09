using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Sail : MonoBehaviour
    {
        private SpriteRenderer m_sr;

        private void Awake() {
            m_sr = this.GetComponent<SpriteRenderer>();
        }

        #region External

        public void Unfurl() {
            m_sr.enabled = true;
        }

        public void Furl() {
            m_sr.enabled = false;
        }

        #endregion // External
    }
}