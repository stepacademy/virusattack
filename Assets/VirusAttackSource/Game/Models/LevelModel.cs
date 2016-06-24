using System.Collections.Generic;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Models {

    using BattleField;
    using Views.BattleField;
    using Controllers.BattleField;   
    
    // Facade for game lvl's

    [AddComponentMenu("Virus-Attack/LevelModel")]
    public sealed class LevelModel : Model<VirusAttack> {

        private List<GameObject>     _hierarchy;

        private BattleFieldModel _battleField;
        public  BattleFieldModel BattleField { get { return _battleField = Assert(_battleField); } }

        [SerializeField] private BattleFieldInspector _battleFieldInspector;

        internal void BuildUnityHierarchyTree() {

            if (_hierarchy == null)
                _hierarchy = new List<GameObject>();

            _hierarchy.Add(new UnityHierarchyComponentBuilder()
                .SetName("BattleField").SetParent(transform)
                .AddComponent(typeof(BattleFieldModel))
                .AddComponent(typeof(BattleFieldView))
                .AddComponent(typeof(BattleFieldController)).Build());

            BattleField.BuildUnityHierarchyTree();
        }

        internal void PrepareInfrastructure() {
            BattleField.SetPreset(_battleFieldInspector).Generate();
        }

        internal void StartGame() {
            BattleField.StartWaves();
        }
    }
}