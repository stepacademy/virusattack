using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models {

    using BattleField;
    
    // Facade for game lvl's

    [AddComponentMenu("Virus-Attack/LevelModel")]
    public sealed class LevelModel : Model<VirusAttack> {

        private BattleFieldModel _battleField;
        public  BattleFieldModel BattleField { get { return _battleField = Assert(_battleField); } }

        [SerializeField] private BattleFieldInspector _battleFieldInspector;

        internal void PrepareInfrastructure() {
            BattleField.SetPreset(_battleFieldInspector).Generate();
        }

        internal void StartGame() { }
    }
}