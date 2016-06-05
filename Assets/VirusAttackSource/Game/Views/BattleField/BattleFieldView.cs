using UnityEngine;
using Assets.VirusAttackSource.AMVCC;


namespace Assets.VirusAttackSource.Game.Views.BattleField {

    [AddComponentMenu("Virus-Attack Source/Views/BattleField/BattleFieldView")]
    public sealed class BattleFieldView : View<VirusAttack> {

        public void OnBattleFieldSuccessInstantiate(string platformName) {
            app.controller.BattleField.Notify("ground.platformInstantiate", platformName);
        }
    }
}