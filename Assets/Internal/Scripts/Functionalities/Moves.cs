using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren.Functionalities
{ 
    public class Moves : MonoBehaviour
    {
        [SerializeField] private GameObject m_referenceObj;
        [SerializeField] private float m_speed;

        public void MoveTowardRef() {
            if (m_referenceObj == null) {
                Debug.Log("[Moves] GameObject with name " + this.gameObject.name + " has no frame of reference for movement.");
                return;
            }

            Vector3 moveDir = (m_referenceObj.transform.position - this.transform.position).normalized;
            Vector3 moveVector = moveDir * m_speed * Time.deltaTime;

            this.transform.Translate(moveVector);
        }
    }
}