using UnityEngine;
using VirusAttackSource.AMVCC;

namespace VirusAttackSource.Game.Controllers.BattleField {

    public sealed class BattleFieldController : Controller<VirusAttack> {

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                case "ground.platformInstantiate":
                    Log(p_data[0] + " - Instantiated!");
                    break;
            }
        }
    }
}