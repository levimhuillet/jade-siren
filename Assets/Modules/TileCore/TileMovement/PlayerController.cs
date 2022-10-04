using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Tiles
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float m_minStepTime; // min time between steps
        private float m_stepTimer;

        private PlayerMovement m_moveControls;

        private bool m_moveHeld; // whether movement input is being held down
        private enum MoveDir {
            None,
            Vertical,
            Horizontal
        }
        private MoveDir m_prevMoveDir;

        #region Unity Callbacks

        void Awake() {
            m_moveControls = new PlayerMovement();
        }

        private void OnEnable() {
            m_moveControls.Enable();
        }

        private void OnDisable() {
            m_moveControls.Enable();
        }

        private void Start() {
            m_moveControls.Main.Movement.performed += ctx => HandleMovementPerformed();
            m_moveControls.Main.Movement.canceled += ctx => HandleMovementCanceled();

            m_moveHeld = true;
        }

        private void Update() {
            if (m_moveHeld) {
                if (m_stepTimer == 0) {
                    Vector2 moveVector = m_moveControls.Main.Movement.ReadValue<Vector2>();
                    if (moveVector.x != 0 && moveVector.y != 0) {
                        // assign precedence to change in direction
                        switch (m_prevMoveDir) {
                            case MoveDir.None:
                                // does not matter
                                moveVector.y = 0;
                                moveVector.x = 1 * Mathf.Sign(moveVector.x);
                                m_prevMoveDir = MoveDir.Horizontal;
                                break;
                            case MoveDir.Vertical:
                                moveVector.y = 0;
                                moveVector.x = 1 * Mathf.Sign(moveVector.x);
                                m_prevMoveDir = MoveDir.Horizontal;
                                break;
                            case MoveDir.Horizontal:
                                moveVector.x = 0;
                                moveVector.y = 1 * Mathf.Sign(moveVector.y);
                                m_prevMoveDir = MoveDir.Vertical;
                                break;
                            default:
                                break;
                        }
                    }
                    Vector3 projectedPos = this.transform.position + (Vector3)moveVector;
                    Type tileType = TilemapMgr.Instance.QueryTileType(projectedPos);
                    bool canMove = CanMoveInto(tileType);

                    if (canMove) {
                        this.transform.position += (Vector3)moveVector;
                        m_stepTimer = m_minStepTime;

                        if (moveVector.y != 0) {
                            m_prevMoveDir = MoveDir.Vertical;
                        }
                        else {
                            m_prevMoveDir = MoveDir.Horizontal;
                        }
                    }
                }
                else {
                    m_stepTimer = Mathf.Max(m_stepTimer - Time.deltaTime, 0);
                }
            }
        }

        #endregion // Unity Callbacks

        private bool CanMoveInto(Type tileType) {
            return tileType == Type.Walkable;
        }

        #region Handlers

        private void HandleMovementPerformed() {
            m_moveHeld = true;
        }

        private void HandleMovementCanceled() {
            m_moveHeld = true;
        }

        #endregion // Handlers
    }

}