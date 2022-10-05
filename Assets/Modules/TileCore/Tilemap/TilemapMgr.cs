using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.Tiles
{
    public class TilemapMgr : MonoBehaviour
    {
        public static TilemapMgr Instance;

        #region TileData

        [SerializeField]
        private List<TileDataCore> m_tileDataList;

        private Dictionary<TileBase, TileDataCore> m_tileDataDict;

        #endregion

        [SerializeField]
        private Tilemap m_map;

        public void Init() {
            Instance = this;

            m_tileDataDict = ConstructTileDataDict();
        }

        public void SetTilemap(Tilemap map) {
            m_map = map;
        }

        #region Init

        public Dictionary<TileBase, TileDataCore> ConstructTileDataDict() {
            Dictionary<TileBase, TileDataCore> dict = new Dictionary<TileBase, TileDataCore>();

            foreach (TileDataCore tileData in m_tileDataList) {
                foreach (var tile in tileData.Tiles) {
                    dict.Add(tile, tileData);
                }
            }

            return dict;
        }

        #endregion // Init

        #region Queries

        public TileDataCore QueryTileAt(Vector3 queryPos) {
            Vector3Int gridPos = m_map.WorldToCell(queryPos);
            TileBase currTile = m_map.GetTile(gridPos);
            if (currTile == null) { return null; }

            TileDataCore data = m_tileDataDict[currTile];
            return data;
        }

        public TileDataCore QueryDataOfTile(TileBase queryTile) {
            if (queryTile != null) {
                return m_tileDataDict[queryTile];
            }
            else {
                return null;
            }
        }
        
        public Tilemap GetCurrMap() {
            return m_map;
        }

        public void SwitchMap(Tilemap switchTo) {
            m_map = switchTo;
        }

        #endregion // Queries
    }
}