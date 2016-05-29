using VirusAttackSource.AMVCC;


namespace VirusAttackSource.Game.Views.BattleField {

    public sealed class BattleFieldView : View<VirusAttack> {

        public void OnPlatformInstantiate(string platformName) {
            app.controller.BattleField.Notify("ground.platformInstantiate", platformName);
        }
    }
}