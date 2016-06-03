using UnityEngine;
using VirusAttackSource.AMVCC;


namespace VirusAttackSource.Game.Views.BattleField {

    [AddComponentMenu("Virus-Attack Source/Views/BattleField/BattleFieldView")]
    public sealed class BattleFieldView : View<VirusAttack> {

        public void OnPlatformInstantiate(string platformName) {
            app.controller.BattleField.Notify("ground.platformInstantiate", platformName);
        }
    }
}