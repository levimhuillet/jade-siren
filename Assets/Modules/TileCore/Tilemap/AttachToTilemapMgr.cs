using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.Tiles
{
    [RequireComponent(typeof(Tilemap))]
    public class AttachToTilemapMgr : MonoBehaviour
    {
        [SerializeField] private bool m_attachOnAwake = true;

        private void Awake() {
            if (m_attachOnAwake) {
                TilemapMgr.Instance.SetTilemap(this.GetComponent<Tilemap>());
            }
        }
    }
}
