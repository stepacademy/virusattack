using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Controllers.BattleField.Base {

    [AddComponentMenu("Virus-Attack/BattleField/Base/BaseController")]
    public sealed class BaseController : Controller<VirusAttack> {

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                case "base.instantiate":
                    Log(p_event + " > Success!\n");
                    break;

            }
        }
    }
}