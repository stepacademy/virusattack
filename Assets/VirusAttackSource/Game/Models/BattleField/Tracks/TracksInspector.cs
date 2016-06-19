using System;
using UnityEngine;

namespace Assets.VirusAttackSource.Game.Models.BattleField.Tracks {

    using Support;

    [Serializable]
    internal sealed class TracksInspector {

        [SerializeField] private TracksType _tracksType;

        [SerializeField] private int        _cellsResolutionWidth  = 6;
        [SerializeField] private int        _cellsResolutionLength = 14;

        [SerializeField] private GameObject _platformGroundPrefab  = null;
        [SerializeField] private GameObject _platformWallPrefab    = null;
        [SerializeField] private GameObject _defendersWallPrefab   = null;

        private int ResolutionFixer(ref int target) {
            return target = target > 3 ? target : 3;
        }

        public TracksType TracksType            { get { return _tracksType;                                 } }
        public int        CellsResolutionWidth  { get { return ResolutionFixer(ref _cellsResolutionWidth);  } }
        public int        CellsResolutionLength { get { return ResolutionFixer(ref _cellsResolutionLength); } }
        public GameObject PlatformGroundPrefab  { get { return _platformGroundPrefab;                       } }
        public GameObject PlatformWallPrefab    { get { return _platformWallPrefab;                         } }
        public GameObject DefendersWallPrefab   { get { return _defendersWallPrefab;                        } }

    }
}