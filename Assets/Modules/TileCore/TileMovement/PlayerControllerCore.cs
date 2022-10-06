using System.Collections;
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
        protected bool m_midStep; // whether the player is mid-step

        [SerializeField] protected float m_walkSpeed;
        [SerializeField] protected float m_sprintSpeed;

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
            // Subscribe to input events
            m_moveControls.Main.Movement.performed += ctx => HandleMovementPerformed();
            m_moveControls.Main.Movement.canceled += ctx => HandleMovementCanceled();
            m_moveControls.Main.Sprint.performed += ctx => HandleSprintPerformed();
            m_moveControls.Main.Sprint.canceled += ctx => HandleSprintCanceled();

            m_moveHeld = false;
            m_sprintHeld = false;
            m_midStep = false;
        }

        protected void FixedUpdate() {
            if (m_moveHeld) {
                if (!m_midStep) {
                    m_moveVector = m_moveControls.Main.Movement.ReadValue<Vector2>();
                    AssignDirPrecedence();
                    Vector3 projectedPos = GetProjectedPos();
                    TileDataCore tileData = TilemapMgr.Instance.QueryTileAt(projectedPos);
                    bool canMove = CanMoveInto(tileData);

                    // Debug.Log("start pos world: " + this.transform.position);
                    // Debug.Log("dest pos world: " + projectedPos);

                    if (canMove) {
                        Vector3 relativeDestPos = this.transform.InverseTransformPoint(projectedPos) + this.transform.localPosition;
                        StartCoroutine(MoveTo(relativeDestPos));
                    }

                    // update move dir
                    UpdateMoveDir();
                }
            }
            else {
                m_moveVector = Vector2.zero;
            }
        }

        #endregion // Unity Callbacks

        #region Helpers

        protected virtual bool CanMoveInto(TileDataCore tileData) {
            if (tileData == null) { return false; }
            return tileData.TileType() == Type.Walkable;
        }

        private void AssignDirPrecedence() {
            Dir prevDir = m_moveDir;
            if (m_moveVector.x != 0 && m_moveVector.y != 0) {
                // assign precedence to change in direction
                if (prevDir == Dir.None || prevDir == Dir.Up || prevDir == Dir.Down) {
                    m_moveVector.y = 0;
                    m_moveVector.x = 1 * Mathf.Sign(m_moveVector.x);
                }
                else if (prevDir == Dir.Left || prevDir == Dir.Right) {
                    m_moveVector.x = 0;
                    m_moveVector.y = 1 * Mathf.Sign(m_moveVector.y);
                }
            }
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

        private IEnumerator MoveTo(Vector3 destPosRelative) {
            //Debug.Log("start pos relative: " + this.transform.localPosition);
            //Debug.Log("dest pos relative: " + destPosRelative);

            m_midStep = true;
            Vector2 normalizedDir = (destPosRelative - this.transform.localPosition).normalized;

            while (Vector3.Distance(this.transform.localPosition, destPosRelative) > 0.01f) {
                float speed = m_sprintHeld ? m_sprintSpeed : m_walkSpeed;
                Vector3 newPos = this.transform.localPosition;

                // move x closer
                float projectedX = this.transform.localPosition.x + normalizedDir.x * speed * Time.deltaTime;
                if (normalizedDir.x > 0) {
                    newPos.x = Mathf.Min(destPosRelative.x, projectedX);
                }
                else {
                    newPos.x = Mathf.Max(destPosRelative.x, projectedX);
                }

                // move y closer
                float projectedY = this.transform.localPosition.y + normalizedDir.y * speed * Time.deltaTime;
                if (normalizedDir.y > 0) {
                    newPos.y = Mathf.Min(destPosRelative.y, projectedY);
                }
                else {
                    newPos.y = Mathf.Max(destPosRelative.y, projectedY);
                }

                this.transform.localPosition = newPos;
                yield return null;
            }

            this.transform.localPosition = destPosRelative;

            m_midStep = false;
        }

        protected Vector3 GetProjectedPos() {
            Vector3 rotatedVector = this.transform.rotation * m_moveVector;
            Vector3 projectedPos = this.transform.position + rotatedVector;
            return projectedPos;
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