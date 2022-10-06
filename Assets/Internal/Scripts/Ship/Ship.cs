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

        private enum State
        { 
            Left,
            Right,
            Up,
            Down
        }

        private State m_state;


        #region Callbacks

        private void Awake() {
            if (m_onDeck == null) {
                m_onDeck = new List<GameObject>();
            }

            for (int o = 0; o < m_onDeck.Count; o++) {
                m_onDeck[o].transform.parent = this.transform;
            }

            m_state = State.Left;
        }

        private void FixedUpdate() {
            Vector2 moveVector = Vector2.zero;

            switch (m_state) { 
                case State.Right:
                    moveVector = Vector2.right;
                    if (this.transform.position.x > 3) {
                        m_state = State.Up;
                    }
                    break;
                case State.Up:
                    moveVector = Vector2.up;

                    if (this.transform.position.y > 1) {
                        m_state = State.Left;
                    }
                    break;
                case State.Left:
                    moveVector = Vector2.left;

                    if (this.transform.position.x < -3) {
                        m_state = State.Down;
                    }
                    break;
                case State.Down:
                    moveVector = Vector2.down;

                    if (this.transform.position.y < -1) {
                        m_state = State.Right;
                    }
                    break;
                default:
                    break;
            }

            MoveShip(moveVector);

            RotateShip();
        }

        #endregion // Callbacks

        #region Movement

        private void MoveShip(Vector2 moveVector) {
            this.transform.position += (Vector3)moveVector * m_speed * Time.deltaTime;
        }

        private void RotateShip() {
            
            Vector3 angles = transform.rotation.eulerAngles;
            angles.z = angles.z + (m_rotateSpeed) * Time.deltaTime;
            if (angles.z > 360) {
                angles.z = 0;
            }
            transform.rotation = Quaternion.Euler(angles);
            m_rotateSpeed += m_rotationIncrease * Time.deltaTime;
        }

        #endregion // Movement
    }
}
