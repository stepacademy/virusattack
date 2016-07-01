using UnityEngine;
using Assets.VirusAttackSource.AMVCC;

namespace Assets.VirusAttackSource.Game.Models.TMP {

    public class BoosterMenuModel : Model<VirusAttack> {

        private bool currentMenuState;

        [SerializeField] private Animator _boosterMenu;

        public void Execute() {
            _boosterMenu.SetBool("isHidden", currentMenuState);
            currentMenuState = !currentMenuState;
        }

        public BoosterMenuModel() {
            currentMenuState = false;
        }
    }

}