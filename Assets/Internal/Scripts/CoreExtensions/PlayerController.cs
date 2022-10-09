using Core.Tiles;
using Core.Animation;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using Siren.Functionalities.Interactables;
using Siren.Functionalities.Triggerables;
using UnityEditor;
using Siren.Functionalities;

namespace Siren
{
    [RequireComponent(typeof(AnimatedChar))]
    public class PlayerController : PlayerControllerCore
    {
        private AnimatedChar m_animatedCharComp;
        private ChangesInputScheme m_inputSchemeComp;

        new private void Awake() {
            // controls now initialized through InputMgr
            // base.Awake();
            m_inputSchemeComp = GetComponent<ChangesInputScheme>();
            m_inputSchemeComp.Init();
            m_moveControls = (PlayerMovement)m_inputSchemeComp.GetInputScheme();

            m_animatedCharComp = GetComponent<AnimatedChar>();

            m_moveDir = Dir.Down;
        }

        new private void OnEnable() {
            // controls now enabled through input mgr
            // base.OnEnable()
        }

        new private void OnDisable() {
            // controls now disabled through input mgr
            // base.OnDisable()
        }

        new private void Start() {
            base.Start();
        }

        new protected void FixedUpdate() {
            base.FixedUpdate();

            Core.Animation.CharState currState = ConvertMoveVectorToState();
            bool flipX = m_moveDir == Dir.Right;

            m_animatedCharComp.UpdateState((int)m_moveDir, (int)currState, flipX);
        }

        #region Helpers

        private Core.Animation.CharState ConvertMoveVectorToState() {
            if (m_midStep) {
                if (m_sprintHeld) {
                    return Core.Animation.CharState.Running;
                }
                else {
                    return Core.Animation.CharState.Walking;
                }
            }
            else {
                return Core.Animation.CharState.Idle;
            }
        }

        protected override bool CanMoveInto(TileDataCore tileDataCore) {
            if (!base.CanMoveInto(tileDataCore)) {
                return false;
            }

            // check for interactables
            if (!CanMoveIntoInteractable()) {
                return false;
            }

            // check for triggerables
            if (!CanMoveIntoTriggerable()) {
                return false;
            }

            return true;
        }

        private bool CanMoveIntoInteractable() {
            int interactMask = 1 << LayerMask.NameToLayer("Interact");
            Collider2D interactHit = Physics2D.OverlapPoint((Vector2)GetProjectedPos(), interactMask);
            if (interactHit != null) {
                Interactable interactable = interactHit.gameObject.GetComponent<Interactable>();

                if (interactable.EnterInitiates) {
                    // invoke interact event
                    interactable.InitiateInteract(this.gameObject);
                }

                if (!interactable.Walkable) {
                    return false;
                }
            }
            return true;
        }
        private bool CanMoveIntoTriggerable() {
            int triggerMask = 1 << LayerMask.NameToLayer("Trigger");
            Collider2D triggerHit = Physics2D.OverlapPoint((Vector2)GetProjectedPos(), triggerMask);

            if (triggerHit != null) {
                Triggerable triggerable = triggerHit.gameObject.GetComponent<Triggerable>();

                if (triggerable.EnterInitiates) {
                    // invoke trigger event
                    triggerable.InitiateTrigger(this.gameObject);
                }

                if (!triggerable.Walkable) {
                    return false;
                }
            }

            return true;
        }

        #endregion // Helpers

        #region PlayerControllerCore Handlers

        protected override void HandleInteractPerformed() {
            base.HandleInteractPerformed();

            int interactMask = 1 << LayerMask.NameToLayer("Interact");
            Collider2D interactHit = Physics2D.OverlapPoint((Vector2)GetPosInFront(), interactMask);
            if (interactHit != null) {
                Interactable interactable = interactHit.gameObject.GetComponent<Interactable>();
                
                // invoke interact event
                interactable.InitiateInteract(this.gameObject);
            }
        }

        #endregion // PlayerControllerCore Handlers
    }
}
