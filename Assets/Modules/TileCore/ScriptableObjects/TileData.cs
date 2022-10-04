using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.Tiles
{
    // The movement classification of this type of tile
    public enum Type
    {
        None,
        Walkable,
        Obstacle
    }

    [CreateAssetMenu]
    public class TileData : ScriptableObject
    {
        public TileBase[] Tiles; // the tiles that incorporate this data

        [SerializeField]
        private Type m_tileType;

        public Type TileType() {
            return m_tileType;
        }
    }
}