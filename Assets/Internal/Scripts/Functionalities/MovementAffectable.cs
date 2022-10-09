using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Functionalities
{
    public class MovementAffectable : MonoBehaviour
    {

        [SerializeField] private List<Affecters.Type> m_affectedBy;

        private void Awake() {
            if (m_affectedBy == null) {
                m_affectedBy = new List<Affecters.Type>();
            }
        }

        #region Queries

        public bool IsAffectedBy(Affecters.Type affectType) {
            return m_affectedBy.Contains(affectType);
        }

        #endregion // Queries
    }
}

