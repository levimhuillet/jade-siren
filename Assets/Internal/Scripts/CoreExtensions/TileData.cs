using Core.Tiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Siren
{
    [CreateAssetMenu]
    public class TileData : TileDataCore
    {
        [SerializeField] private bool m_startsHidden;
        [SerializeField] private Sprite m_editorSprite; // only used if hidden

        public bool StartsHidden {
            get { return m_startsHidden; }
        }
        public Sprite EditorSprite {
            get { return m_editorSprite; }
        }
    }
}
