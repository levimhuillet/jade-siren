using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float m_speed;
        [SerializeField] private float m_rotateSpeed;
        [SerializeField] private float m_rotationIncrease;

        [SerializeField] private List<GameObject> m_onDeck;


        #region Callbacks

        private void Awake() {
            if (m_onDeck == null) {
                m_onDeck = new List<GameObject>();
            }

            for (int o = 0; o < m_onDeck.Count; o++) {
                m_onDeck[o].transform.parent = this.transform;
            }
        }

        private void FixedUpdate() {
            //CalcShipMoveVector();

            //MoveShip(moveVector);

            //RotateShip();
        }

        #endregion // Callbacks

        
    }
}
