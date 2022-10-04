using Core.Tiles;
using UnityEngine;

namespace Siren
{
    public class Bootstrap : MonoBehaviour
    {
        public static Bootstrap Instance;

        [SerializeField] private TilemapMgr m_tilemapMgr;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else if (Instance != this) {
                Destroy(this.gameObject);
                return;
            }

            m_tilemapMgr.Init();
        }
    }
}