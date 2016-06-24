using System.Text;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Controllers {

    using BattleField;

    [AddComponentMenu("Virus-Attack/LevelController")]
    public sealed class LevelController : Controller<VirusAttack> {

        private BattleFieldController _battleField;
        public  BattleFieldController BattleField { get { return _battleField = Assert(_battleField); } }

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                case "scene.load":
                    OnSceneLoad(p_data);
                    break;
                case "scene.start":
                    OnSceneStart(p_data);
                    break;
                default:
                    // Log(OnDefault(p_event, p_target, p_data)); // Interception all, uncoment for debug...
                    break;
            }
        }

        internal void OnSceneLoad(params object[] p_data) {
            app.model.BuildUnityHierarchyTree();
            app.model.PrepareInfrastructure();
            Log(p_data[0] + ", Id: " + p_data[1] + " > Loaded!\n");
        }

        internal void OnSceneStart(params object[] p_data) {

            Log(p_data[0] + ", Id: " + p_data[1] + " > Started!\n");
            app.model.StartGame();
        }

        internal string OnDefault(string p_event, Object p_target, params object[] p_data) {

            StringBuilder message = new StringBuilder()
                .Append(" Event: ")
                .Append(p_event)
                .Append(" > Target: ")
                .Append(p_target.GetType().Name)
                .Append("\nReceived Data: ");

            foreach (var item in p_data)
                message.Append(item + ", ");

            return message.ToString();

        }        
    }
}