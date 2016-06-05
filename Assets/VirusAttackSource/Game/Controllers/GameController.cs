using System.Text;
using UnityEngine;
using VirusAttackSource.AMVCC;


namespace VirusAttackSource.Game.Controllers {

    using BattleField;

    [AddComponentMenu("Virus-Attack Source/Controllers/GameController")]
    public sealed class GameController : Controller<VirusAttack> {

        private BattleFieldController _battleField;
        public  BattleFieldController BattleField { get { return _battleField = Assert(_battleField); } }

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                default: // for debug

                    StringBuilder message = new StringBuilder();
                    message
                        .Append("перехватил событие: ")
                        .Append(p_event)
                        .Append(". Cобытие предназначено для: ")
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