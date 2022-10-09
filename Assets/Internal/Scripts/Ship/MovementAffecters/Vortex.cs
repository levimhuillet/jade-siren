using Siren.Functionalities;
using Siren.Functionalities.Affecters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Affecters
{
    [RequireComponent(typeof(AffectsMovement))]
    public class Vortex : MonoBehaviour, IAffectsMovement
    {
        private AffectsMovement m_affecterComp;

        [SerializeField] private float m_translateSpeed;
        [SerializeField] private float m_rotateSpeed;
        [SerializeField] private float m_rotationIncrease;

        private enum SwirlPhase
        {
            Left,
            Right,
            Up,
            Down
        }

        private SwirlPhase m_swirlPhase;

        private void Awake() {
            m_affecterComp = this.GetComponent<AffectsMovement>();
            m_affecterComp.EffectFuncHandler = MovementEffect;

            m_swirlPhase = SwirlPhase.Left;
        }


        #region IAffectsMovement

        public void MovementEffect(MovementAffectable toMove) {
            if (toMove.GetComponent<Ship>() != null) {
                Vector3 moveVector = CalcSwirlPhaseVector(toMove);

                MoveShip(toMove, moveVector);
                RotateShip(toMove);
            }
        }

        // public void ShipMovementEffect(MovementAffectable toMove)

        // public void TentactlesMovementEffect(MovementAffectable toMove)

        #endregion // IAffectsMovemet

        #region Helpers

        private Vector2 CalcSwirlPhaseVector(MovementAffectable toMove) {
            Vector2 moveVector = Vector2.zero;

            switch (m_swirlPhase) {
                case SwirlPhase.Right:
                    moveVector = Vector2.right;
                    if (toMove.transform.position.x > 3) {
                        m_swirlPhase = SwirlPhase.Up;
                    }
                    break;
                case SwirlPhase.Up:
                    moveVector = Vector2.up;

                    if (toMove.transform.position.y > 1) {
                        m_swirlPhase = SwirlPhase.Left;
                    }
                    break;
                case SwirlPhase.Left:
                    moveVector = Vector2.left;

                    if (toMove.transform.position.x < -3) {
                        m_swirlPhase = SwirlPhase.Down;
                    }
                    break;
                case SwirlPhase.Down:
                    moveVector = Vector2.down;

                    if (toMove.transform.position.y < -1) {
                        m_swirlPhase = SwirlPhase.Right;
                    }
                    break;
                default:
                    break;
            }

            return moveVector;
        }

        private void MoveShip(MovementAffectable toMove, Vector2 moveVector) {
            toMove.transform.position += (Vector3)moveVector * m_translateSpeed * Time.deltaTime;
        }

        private void RotateShip(MovementAffectable toMove) {
            Vector3 angles = toMove.transform.rotation.eulerAngles;
            angles.z = angles.z + (m_rotateSpeed) * Time.deltaTime;
            toMove.transform.rotation = Quaternion.Euler(angles);
            m_rotateSpeed += m_rotationIncrease * Time.deltaTime;
        }

        #endregion // Helpers
    }
}
