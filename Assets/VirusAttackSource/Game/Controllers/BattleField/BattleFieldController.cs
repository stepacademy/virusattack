using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Controllers.BattleField {

    [AddComponentMenu("Virus-Attack/BattleField/BattleFieldController")]
    public sealed class BattleFieldController : Controller<VirusAttack> {

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                case "ground.instantiate":
                    Log(p_event + "\nSuccess!");
                    break;
            }

        }
    }
}