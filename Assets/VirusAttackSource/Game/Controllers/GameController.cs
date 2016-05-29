using VirusAttackSource.AMVCC;


namespace VirusAttackSource.Game.Controllers {

    using BattleField;

    public sealed class GameController : Controller<VirusAttack> {

        private BattleFieldController _battleField;
        public  BattleFieldController BattleField { get { return _battleField = Assert(_battleField); } }

    }
}