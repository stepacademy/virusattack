using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Views {

    using BattleField;
    using Unit;

    [AddComponentMenu("Virus-Attack/LevelView")]
    public sealed class LevelView : View<VirusAttack> {

        // BattleField

        private BattleFieldView _battleField;
        public  BattleFieldView BattleField { get { return _battleField = Assert(_battleField); } }

        // Unit

        private UnitView             _unit;
        private UnitCollisionView    _unitCollision;

        public  UnitView             Unit             { get { return _unit = Assert(_unit);                   } }      
        public  UnitCollisionView    UnitCollision    { get { return _unitCollision = Assert(_unitCollision); } }
    }
}