using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.VirusAttackSource.Game.Models.BattleField.Waves {

    using Support;

    [Serializable]
    internal sealed class WavesInspector {

        [SerializeField] private List<Wave> _waves = null;

        public List<Wave> Waves { get { return _waves; } set { _waves = value; } }
    }
}