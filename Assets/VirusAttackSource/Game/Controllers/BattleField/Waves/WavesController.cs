using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Controllers.BattleField.Waves {

    [AddComponentMenu("Virus-Attack/BattleField/Waves/WavesController")]
    public sealed class WavesController : Controller<VirusAttack> {

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                case "waves.invokeNext":
                    app.model.BattleField.Waves.Generate();
                    break;

            }
        }
    }
}