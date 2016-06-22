using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Controllers.Unit {

    [AddComponentMenu("Virus-Attack/Unit/UnitController")]
    public sealed class UnitController : Controller<VirusAttack> {

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                case "@collision.enter":                // <-- "Unit Name" from 
                    Log(p_data[0] + " - enter!");       // p_data <-- collision with ...
                    break;
            }

        }
    }
}