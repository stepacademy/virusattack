using System.Text;
using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Controllers {

    using BattleField;

    [AddComponentMenu("Virus-Attack Source/LevelController")]
    public sealed class LevelController : Controller<VirusAttack> {

        private BattleFieldController _battleField;
        public  BattleFieldController BattleField { get { return _battleField = Assert(_battleField); } }

        internal void OnSceneLoad(params object[] p_data) {

            app.model.GenerateBattleField();

            Log(new StringBuilder("Level: ")
                .Append(p_data[0])
                .Append(", Id: ")
                .Append(p_data[1])
                .Append("\nLoaded!"));
        }

        internal void OnSceneStart(params object[] p_data) {

            Log(new StringBuilder("Level: ")
                .Append(p_data[0])
                .Append(", Id: ")
                .Append(p_data[1])
                .Append("\nStarted!"));

            app.model.StartEnemiesSpawn();
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

        public override void OnNotification(string p_event, Object p_target, params object[] p_data) {

            switch (p_event) {

                case "scene.load":
                    OnSceneLoad(p_data);
                    break;
                case "scene.start":
                    OnSceneStart(p_data);
                    break;
                default:
                    // Log(OnDefault(p_event, p_target, p_data)); // Spam off, uncoment for debug...
                    break;
            }

        }
    }
}