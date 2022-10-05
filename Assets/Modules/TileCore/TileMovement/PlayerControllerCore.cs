using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Tiles
{
    public enum Dir
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    public class PlayerControllerCore : MonoBehaviour
    {
        [SerializeField] protected float m_minStepTime; // min time between steps
        protected float m_stepTimer;

        protected PlayerMovement m_moveControls;

        protected bool m_moveHeld; // whether movement input is being held down
        protected bool m_sprintHeld; // whether sprint input is being held down

        protected Dir m_moveDir;
        protected Vector3 m_moveVector;

        #region Unity Callbacks

        protected void Awake() {
            m_moveControls = new PlayerMovement();
        }

        protected void OnEnable() {
            m_moveControls.Enable();
        }

        protected void OnDisable() {
            m_moveControls.Enable();
        }

        protected void Start() {
            m_moveControls.Main.Movement.performed += ctx => HandleMovementPerformed();
            m_moveControls.Main.Movement.canceled += ctx => HandleMovementCanceled();
            m_moveControls.Main.Sprint.performed += ctx => HandleSprintPerformed();
            m_moveControls.Main.Sprint.canceled += ctx => HandleSprintCanceled();

            m_moveHeld = false;
            m_sprintHeld = false;
        }

        protected void Update() {
            if (m_moveHeld) {
                if (m_stepTimer == 0) {
                    m_moveVector = m_moveControls.Main.Movement.ReadValue<Vector2>();
                    AssignDirPrecedence();

                    Vector3 projectedPos = this.transform.position + m_moveVector;
                    Type tileType = TilemapMgr.Instance.QueryTileType(projectedPos);
                    bool canMove = CanMoveInto(tileType);

                    if (canMove) {
                        MovePlayer();

                        m_stepTimer = m_sprintHeld ? m_minStepTime / 2f : m_minStepTime;

                        // update move dir
                        UpdateMoveDir();
                    }
                }
                else {
                    m_stepTimer = Mathf.Max(m_stepTimer - Time.deltaTime, 0);
                }
            }
            else {
                m_moveVector = Vector2.zero;
            }
        }

        #endregion // Unity Callbacks

        #region Helpers

        protected bool CanMoveInto(Type tileType) {
            return tileType == Type.Walkable;
        }

        private void AssignDirPrecedence() {
            Dir prevDir = m_moveDir;
            if (m_moveVector.x != 0 && m_moveVector.y != 0) {
                // assign precedence to change in direction
                if (prevDir == Dir.None || prevDir == Dir.Up || prevDir == Dir.Down) {
                    m_moveVector.y = 0;
                }
                else if (prevDir == Dir.Left || prevDir == Dir.Right) {
                    m_moveVector.x = 0;
                }
            }
        }

        private void MovePlayer() {
            this.transform.position += m_moveVector;
        }

        private void UpdateMoveDir() {
            if (m_moveVector.x != 0) {
                if (m_moveVector.x > 0) {
                    m_moveDir = Dir.Right;
                }
                else if (m_moveVector.x < 0) {
                    m_moveDir = Dir.Left;
                }
                else {
                    m_moveDir = Dir.None;
                }
            }
            else if (m_moveVector.y != 0) {
                if (m_moveVector.y > 0) {
                    m_moveDir = Dir.Up;
                }
                else if (m_moveVector.y < 0) {
                    m_moveDir = Dir.Down;
                }
                else {
                    m_moveDir = Dir.None;
                }
            }
        }

        #endregion // Helpers

        #region Handlers

        protected void HandleMovementPerformed() {
            m_moveHeld = true;
        }

        protected void HandleMovementCanceled() {
            m_moveHeld = false;
        }

        protected void HandleSprintPerformed() {
            m_sprintHeld = true;
        }

        protected void HandleSprintCanceled() {
            m_sprintHeld = false;
        }

        #endregion // Handlers
    }

}