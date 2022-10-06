using Core.Tiles;
using Core.Animation;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using Siren.Functionalities.Interactable;
using Siren.Functionalities.Triggerable;

namespace Siren
{
    [RequireComponent(typeof(AnimatedChar))]
    public class PlayerController : PlayerControllerCore
    {
        private AnimatedChar m_animatedCharComp;

        new private void Awake() {
            base.Awake();

            m_animatedCharComp = GetComponent<AnimatedChar>();

            m_moveDir = Dir.Down;
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
    }
}
