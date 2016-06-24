using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models.BattleField {

    using Base;
    using Tracks;
    using Waves;
    using Controllers.BattleField.Base;
    using Controllers.BattleField.Tracks;
    using Controllers.BattleField.Waves;

    [AddComponentMenu("Virus-Attack/BattleField/BattleFieldModel")]
    public sealed class BattleFieldModel : Model<VirusAttack> {

        private List<GameObject>     _hierarchy;
        private BattleFieldInspector _inspector;

        private BaseModel   _base;
        private TracksModel _tracks;
        private WavesModel  _waves;

        internal BaseModel   Base   { get { return _base   = Assert(_base);   } }
        internal TracksModel Tracks { get { return _tracks = Assert(_tracks); } }
        internal WavesModel  Waves  { get { return _waves  = Assert(_waves);  } }

        internal void BuildUnityHierarchyTree() {

            if (_hierarchy == null)
                _hierarchy = new List<GameObject>();

            _hierarchy.Add(new UnityHierarchyComponentBuilder()
                .SetName("Base").SetParent(transform)
                .AddComponent(typeof(BaseModel)).AddComponent(typeof(BaseController)).Build());

            _hierarchy.Add(new UnityHierarchyComponentBuilder()
                .SetName("Tracks").SetParent(transform)
                .AddComponent(typeof(TracksModel)).AddComponent(typeof(TracksController)).Build());

            _hierarchy.Add(new UnityHierarchyComponentBuilder()
                .SetName("Waves").SetParent(transform)
                .AddComponent(typeof(WavesModel)).AddComponent(typeof(WavesController)).Build());
        }

        internal BattleFieldModel SetPreset(BattleFieldInspector battleFieldInspector) {

            _inspector = battleFieldInspector;

            Base.SetPreset(_inspector.BaseInspector);
            Tracks.SetPreset(_inspector.TracksInspector);
            Waves.SetPreset(_inspector.WavesInspector);

            return this;
        }

        internal void Generate() {
            Base.Generate();
            Tracks.Generate();
        }       

        internal void StartWaves() {
            Waves.Generate();
        }
    }
}