using System;
using UnityEngine;

namespace Assets.VirusAttackSource.Game.Models.BattleField.Base {

    [Serializable]
    public sealed class BaseInspector {

        [SerializeField] private float _baseXZSize               = 6.0f;
        [SerializeField] private float _bossPercentageScaleRatio = 66.66667f;
        [SerializeField] private GameObject _groundPrefab        = null;
        [SerializeField] private GameObject _bossPrefab          = null;

        internal float      BaseXZSize               { get { return _baseXZSize;               } }
        internal float      BossPercentageScaleRatio { get { return _bossPercentageScaleRatio; } }
        internal GameObject GroundPrefab             { get { return _groundPrefab;             } }
        internal GameObject BossPrefab               { get { return _bossPrefab;               } }

    }
}