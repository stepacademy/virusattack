using VirusAttackSource.AMVCC;


namespace VirusAttackSource.Game.Views {

    using BattleField;

    public sealed class GameView : View<VirusAttack> {

        private BattleFieldView _battleField;
        public  BattleFieldView BattleField { get { return _battleField = Assert(_battleField); } }

    }
}