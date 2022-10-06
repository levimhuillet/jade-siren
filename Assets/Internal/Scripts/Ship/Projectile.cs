using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        private float m_speed;
        private Vector3 m_travelDir;

        private static int DESTROY_BOUNDS = 50;

        private enum State {
            Init,
            Launching,
            Traveling,
            Impacting
        }

        private State m_state;

        #region Callbacks

        private void Update() {
            switch(m_state) {
                case State.Init:
                    break;
                case State.Launching:
                    break;
                case State.Traveling:
                    this.transform.Translate(m_travelDir * m_speed * Time.deltaTime, Space.World);

                    // TEMP HACK SOLUTION
                    if (Vector3.Distance(this.transform.position, Bootstrap.Instance.transform.position) > DESTROY_BOUNDS) {
                        Destroy(this.gameObject);
                    }
                    break;
                case State.Impacting:
                    break;
                default:
                    break;
            }
        }

        #endregion // Callbacks

        #region External 

        public void Init(Vector3 startPos, float speed, Vector3 travelDir) {
            this.transform.position = startPos;
            m_state = State.Init;
            m_speed = speed;
            m_travelDir = travelDir;
        }

        public void Launch() {
            m_state = State.Launching;

            // any launch things here

            m_state = State.Traveling;
        }

        #endregion // External


    }
}
