using System.Text;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Controllers {

    using BattleField;

    [AddComponentMenu("Virus-Attack Source/Controllers/GameController")]
    public sealed class LevelController : Controller<VirusAttack> {

        private BattleFieldController _battleField;
        public  BattleFieldController BattleField { get { return _battleField = Assert(_battleField); } }

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                default:

                    StringBuilder message = new StringBuilder();
                    message
                        .Append(" Событие: ")
                        .Append(p_event)
                        .Append(", предназначено для: ")
                        .Append(p_target.GetType().Name)
                        .Append("\n")
                        .Append("Пересылаемые данные: ");

                    foreach (var item in p_data)
                        message.Append(item + ", ");

                    Log(message);
                    break;
            }

        }
    }
}