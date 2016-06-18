using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Controllers.Spawner {

    [AddComponentMenu("Virus-Attack/Spawner/SpawnerController")]
    public sealed class SpawnerController : Controller<VirusAttack> {

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                case "wave.invokeNext":
                    StartCoroutine(app.model.Spawner.SpawnNextWave());                    
                    break;
            }

        }
    }
}