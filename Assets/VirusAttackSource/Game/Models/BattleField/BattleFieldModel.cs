using System;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models.BattleField {

    using Base;    
    using Tracks;
    using Waves;

    [AddComponentMenu("Virus-Attack/BattleField/BattleFieldModel")]
    public sealed class BattleFieldModel : Model<VirusAttack> {

        private BattleFieldInspector _inspector;

        private BaseModel   _base;
        private TracksModel _tracks;
        private WavesModel  _waves;

        internal BaseModel   Base   { get { return _base   = Assert(_base);   } }
        internal TracksModel Tracks { get { return _tracks = Assert(_tracks); } }
        internal WavesModel  Waves  { get { return _waves  = Assert(_waves);  } }

        internal BattleFieldModel SetPreset(BattleFieldInspector battleFieldInspector) {
            _inspector = battleFieldInspector;
            return this;
        }

        internal void Generate() {
            Base.SetPreset(_inspector.BaseInspector).Generate();
            Tracks.SetPreset(_inspector.TracksInspector).Generate();
            Waves.SetPreset(_inspector.WavesInspector).Generate();
        }
    }
}