using UnityEngine;

namespace Core.Animation
{
    public enum CharState
    {
        Idle,
        Walking,
        Running
    }

    [RequireComponent(typeof(SpriteRenderer))]
    public class AnimatedCharCore : MonoBehaviour
    {
        protected Animator m_animator;
        protected SpriteRenderer m_sr;

        #region Callbacks 

        protected void Awake() {
            m_animator = this.GetComponent<Animator>();
            m_sr = this.GetComponent<SpriteRenderer>();
        }

        #endregion // Callbacks

        public void UpdateState(int facingDir, int state, bool flipX) {
            // Update animator
            m_animator.SetInteger("State", (int)state);
            m_animator.SetInteger("Dir", (int)facingDir);
            m_sr.flipX = flipX;
        }
    }
}
