using UnityEngine;
using VirusAttackSource.AMVCC;


namespace VirusAttackSource.Game.Views {

    using BattleField;
    using Unit;
    
    [AddComponentMenu("Virus-Attack Source/Views/GameView")]
    public sealed class GameView : View<VirusAttack> {

        private BattleFieldView _battleField;
        public  BattleFieldView BattleField { get { return _battleField = Assert(_battleField); } }

        private UnitView _unit;
        public UnitView Unit { get { return _unit = Assert(_unit); } }

    }
}