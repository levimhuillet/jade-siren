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
        private List<TileData> m_tileDataList;

        private Dictionary<TileBase, TileData> m_tileDataDict;

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

        public Dictionary<TileBase, TileData> ConstructTileDataDict() {
            Dictionary<TileBase, TileData> dict = new Dictionary<TileBase, TileData>();

            foreach (TileData tileData in m_tileDataList) {
                foreach (var tile in tileData.Tiles) {
                    dict.Add(tile, tileData);
                }
            }

            return dict;
        }

        #endregion // Init

        #region Queries

        public Type QueryTileType(Vector3 queryPos) {
            Vector3Int gridPos = m_map.WorldToCell(queryPos);
            TileBase currTile = m_map.GetTile(gridPos);
            if (currTile == null) { return Type.None; }

            TileData data = m_tileDataDict[currTile];
            if (data != null) {
                return m_tileDataDict[currTile].TileType();
            }
            else {
                return Type.None;
            }
        }

        #endregion // Queries
    }
}