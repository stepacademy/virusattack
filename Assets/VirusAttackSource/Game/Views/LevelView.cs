using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Views {

    using BattleField;
    using Unit;

    [AddComponentMenu("Virus-Attack/LevelView")]
    public sealed class LevelView : View<VirusAttack> {

        private BattleFieldView _battleField;
        public  BattleFieldView BattleField { get { return _battleField = Assert(_battleField); } }

        private UnitView _unit;
        public  UnitView Unit { get { return _unit = Assert(_unit); } }

    }
}