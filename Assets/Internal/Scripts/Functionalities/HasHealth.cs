using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Functionalities
{
    public class HasHealth : MonoBehaviour
    {
        [SerializeField] private float m_maxHealth;

        private float m_currHealth;

        public event EventHandler OnHealthZero;

        public void Init() {
            m_currHealth = m_maxHealth;
        }

        #region Queries

        public float GetCurrHealth() {
            return m_currHealth;
        }

        #endregion // Queries

        #region Modify Health

        public void Damage(float amt) {
            m_currHealth = Mathf.Max(m_currHealth - amt, 0);

            if (m_currHealth == 0) {
                OnHealthZero?.Invoke(this, EventArgs.Empty);
            }
        } 

        public void Heal(float amt) {
            m_currHealth = Mathf.Min(m_currHealth + amt, m_maxHealth);
        }

        #endregion // Modify Health
    }
}