using Core.Tiles;
using Core.Animation;
using UnityEngine;

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

        new protected void Update() {
            base.Update();

            Core.Animation.CharState currState = ConvertMoveVectorToState();
            bool flipX = m_moveDir == Dir.Right;

            m_animatedCharComp.UpdateState((int)m_moveDir, (int)currState, flipX);
        }

        #region Helpers

        private Core.Animation.CharState ConvertMoveVectorToState() {
            if (m_moveVector.x == 0 && m_moveVector.y == 0) {
                return Core.Animation.CharState.Idle;
            }
            else {
                if (m_sprintHeld) {
                    return Core.Animation.CharState.Running;
                }
                else {
                    return Core.Animation.CharState.Walking;
                }
            }
        }

        #endregion // Helpers
    }
}
