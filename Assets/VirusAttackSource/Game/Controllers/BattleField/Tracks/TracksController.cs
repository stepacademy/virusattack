using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Controllers.BattleField.Tracks {

    [AddComponentMenu("Virus-Attack/BattleField/Tracks/TracksController")]
    public sealed class TracksController : Controller<VirusAttack> {

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                case "tracks.type":
                    Log(p_data[0] + " > Detected!\n");
                    break;

                case "tracks.instantiate":
                    Log("All " + p_event + " > Success!\n");
                    break;

            }
        }
    }
}