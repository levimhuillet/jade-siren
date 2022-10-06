using Siren.Functionalities.Triggerables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Functionalities.Interactables
{
    public class InteractableEventArgs : EventArgs
    {
        public GameObject Initiator { get; set; }

        public InteractableEventArgs(GameObject initiator) {
            Initiator = initiator;
        }
    }

    [RequireComponent(typeof(Collider2D))]
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private bool m_walkable;
        [SerializeField] private bool m_enterInitiates; // whether this initiates with movement

        public bool Walkable {
            get { return m_walkable; }
        }
        public bool EnterInitiates {
            get { return m_enterInitiates; }
        }

        public event EventHandler<InteractableEventArgs> OnInteract;

        private void Awake() {
            if (this.gameObject.layer != LayerMask.NameToLayer("Interact")) {
                Debug.Log("[Interactable] Interactable object " + this.gameObject.name + " not set to layer Interact!");
                this.gameObject.layer = LayerMask.NameToLayer("Interact");
            }
        }

        public void InitiateInteract(GameObject initiator) {
            OnInteract?.Invoke(this, new InteractableEventArgs(initiator));
        }
    }
}