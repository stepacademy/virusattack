using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Controllers.BattleField.Tracks {

    [AddComponentMenu("Virus-Attack/BattleField/Tracks/TracksController")]
    public sealed class TracksController : Controller<VirusAttack> {

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                case "tracks.instantiate":
                    Log(p_event + " > Success!\n");
                    break;

            }
        }
    }
}