using Core.Tiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Siren
{
    [RequireComponent(typeof(Tilemap))]
    public class HideTilePass : MonoBehaviour
    {
        private void OnEnable() {
            Tilemap toPassOver = this.GetComponent<Tilemap>();
            TileBase[] allTiles = toPassOver.GetTilesBlock(toPassOver.cellBounds);

            for (int i = 0; i < allTiles.Length; i++) {
                TileBase currTile = allTiles[i];
                TileDataCore coreData = TilemapMgr.Instance.QueryDataOfTile(currTile);
                if (coreData == null) {
                    continue;
                }

                TileData data = (TileData)coreData;
                if (data.StartsHidden) {
                    ((Tile)currTile).sprite = null;
                }
            }
            toPassOver.RefreshAllTiles();
        }

        private void OnDisable() {
            Tilemap toPassOver = this.GetComponent<Tilemap>();
            TileBase[] allTiles = toPassOver.GetTilesBlock(toPassOver.cellBounds);

            for (int i = 0; i < allTiles.Length; i++) {
                TileBase currTile = allTiles[i];
                TileDataCore coreData = TilemapMgr.Instance.QueryDataOfTile(currTile);
                if (coreData == null) {
                    continue;
                }

                TileData data = (TileData)coreData;
                if (data.StartsHidden) {
                    ((Tile)currTile).sprite = data.EditorSprite;
                }
            }
            toPassOver.RefreshAllTiles();
        }
    }
}