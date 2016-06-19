using System;
using UnityEngine;

namespace Assets.VirusAttackSource.Game.Models.BattleField {

    using Base;
    using Tracks;
    using Waves;

    [Serializable]
    internal sealed class BattleFieldInspector {

        [SerializeField] private BaseInspector   _baseInspector;
        [SerializeField] private TracksInspector _tracksInspector;
        [SerializeField] private WavesInspector  _wavesInspector;

        internal BaseInspector   BaseInspector   { get { return _baseInspector;   } }
        internal TracksInspector TracksInspector { get { return _tracksInspector; } }
        internal WavesInspector  WavesInspector  { get { return _wavesInspector;  } }

    }
}