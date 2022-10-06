using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Functionalities.Triggerable
{
    public class TriggerableEventArgs : EventArgs
    {
        public GameObject Initiator { get; set; }

        public TriggerableEventArgs(GameObject initiator) {
            Initiator = initiator;
        }
    }

    [RequireComponent(typeof(Collider2D))]
    public class Triggerable : MonoBehaviour
    {
        [SerializeField] private bool m_walkable;
        [SerializeField] private bool m_enterInitiates; // whether this initiates with movement

        public bool Walkable {
            get { return m_walkable; }
        }
        public bool EnterInitiates {
            get { return m_enterInitiates; }
        }

        public event EventHandler<TriggerableEventArgs> OnTrigger;

        private void Awake() {
            if (this.gameObject.layer != LayerMask.NameToLayer("Trigger")) {
                Debug.Log("[Triggerable] Triggerable object " + this.gameObject.name + " not set to layer Trigger!");
                this.gameObject.layer = LayerMask.NameToLayer("Trigger");
            }
        }

        public void InitiateTrigger(GameObject initiator) {
            OnTrigger?.Invoke(this, new TriggerableEventArgs(initiator));
        }
    }
}
