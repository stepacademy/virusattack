using UnityEngine;
using VirusAttackSource.AMVCC;

namespace VirusAttackSource.Game.Controllers.Unit {

    public sealed class UnitController : Controller<VirusAttack> {

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                case "unitName.collision.enter":        // <-- "unitName" from 
                    Log(p_data[0] + " - enter!");       // p_data <-- collision with ...
                    break;
            }
        }
    }
}