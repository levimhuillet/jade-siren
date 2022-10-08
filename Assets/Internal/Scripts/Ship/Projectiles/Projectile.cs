using Siren.Targets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Projectiles
{
    public enum Type {
        Cannonball,
        GoldOrb
    }

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Type m_type;
        [SerializeField] private float m_baseDamage;

        private float m_speed;
        private Vector3 m_travelDir;

        private static int DESTROY_BOUNDS = 50; // TEMP HACK

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

        private void OnCollisionEnter2D(Collision2D collision) {
            Target targetComp = collision.gameObject.GetComponent<Target>();
            if (targetComp != null) {
                targetComp.EncounterProjectile(this);
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

        public virtual void TriggerDestroySequence() {
            Destroy(this.gameObject);
        }

        #endregion // External

        #region Queries

        public Type GetProjectileType() {
            return m_type;
        }

        public float GetBaseDamage() {
            return m_baseDamage;
        }

        #endregion // Queries


    }
}
