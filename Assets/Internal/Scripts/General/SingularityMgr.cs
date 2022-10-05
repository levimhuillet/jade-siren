using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Siren
{
    public class SingularityMgr : MonoBehaviour
    {
        [SerializeField] private string m_firstScene;

        // Start is called before the first frame update
        void Start() {
            SceneManager.LoadScene(m_firstScene);
        }
    }
}
