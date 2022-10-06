using Core.Tiles;
using Siren.Functionalities.Triggerables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Siren
{
    [RequireComponent(typeof(Triggerable))]
    public class TriggerTilemapSwitch : MonoBehaviour
    {
        [Serializable]
        private struct SwitchPair
        {
            public Tilemap From;
            public Tilemap To;
        }

        [SerializeField] private List<SwitchPair> m_switchPairs;

        private void Awake() {
            this.GetComponent<Triggerable>().OnTrigger += HandleOnTrigger;
        }

        private void HandleOnTrigger(object sender, EventArgs args) {
            TrySwitch(((TriggerableEventArgs)args).Initiator);
        }

        private bool TrySwitch(GameObject initiator) {
            Tilemap switchFrom = TilemapMgr.Instance.GetCurrMap();

            for (int p = 0; p < m_switchPairs.Count; p++) {
                if (m_switchPairs[p].From == switchFrom) {
                    TilemapMgr.Instance.SwitchMap(m_switchPairs[p].To);
                    initiator.GetComponent<SpriteRenderer>().sortingLayerName = m_switchPairs[p].To.GetComponent<TilemapRenderer>().sortingLayerName;
                    return true;
                }
            }
            return false;
        }
    }
}
