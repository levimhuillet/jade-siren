using Siren.Functionalities.Interactables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Siren.Functionalities
{
    [RequireComponent(typeof(Interactable))]
    public class LoadsScene : MonoBehaviour
    {
        Interactable m_interactableComp;

        [SerializeField] private string m_sceneToLoad;

        private void Start() {
            m_interactableComp = this.GetComponent<Interactable>();
            m_interactableComp.OnInteract += HandleInteract;
        }

        private void HandleInteract(object sender, InteractableEventArgs args) {
            SceneManager.LoadScene(m_sceneToLoad);
        }
    }

}