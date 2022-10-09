using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float m_baseSpeed; // the base speed
        [SerializeField] private int m_maxSails;

        [SerializeField] private List<GameObject> m_onDeck;

        private int m_numSailsUnfurled;


        #region Callbacks

        private void Awake() {
            if (m_onDeck == null) {
                m_onDeck = new List<GameObject>();
            }

            for (int o = 0; o < m_onDeck.Count; o++) {
                m_onDeck[o].transform.parent = this.transform;
            }

            m_numSailsUnfurled = 1; // 0;
        }

        private void FixedUpdate() {
            // move forward
            Vector3 forwardDir = Vector3.up;
            Vector3 forwardVector = forwardDir * m_baseSpeed * m_numSailsUnfurled * Time.deltaTime;
            this.transform.Translate(forwardVector);
        }

        #endregion // Callbacks

        #region External

        public void TryUnfurlSail() {
            if (m_numSailsUnfurled == m_maxSails) {
                Debug.Log("[Ship] All sails already unfurled!");
                return;
            }
            else {
                m_numSailsUnfurled++;
                UnfurlSailSequence(m_numSailsUnfurled);
            }
        }

        public void TryFurlSail() {
            if (m_numSailsUnfurled == 0) {
                Debug.Log("[Ship] All sails already furled!");
                return;
            }
            else {
                FurlSailSequence(m_numSailsUnfurled);
                m_numSailsUnfurled--;
            }
        }

        #endregion // External

        #region Helpers 

        private void UnfurlSailSequence(int sailIndex) {
            Debug.Log("Unfurling sail " + sailIndex);
        }

        private void FurlSailSequence(int sailIndex) {
            Debug.Log("Furling sail " + sailIndex);
        }

        #endregion // Helpers

        #region Queries

        public int GetNumSailsUnfurled() {
            return m_numSailsUnfurled;
        }

        #endregion // Queries

    }
}
