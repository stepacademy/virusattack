using UnityEngine;


public class BoosterMenuScript : MonoBehaviour {

    private bool currentMenuState;

    public Animator boosterMenu;

    public void Execute() {
        boosterMenu.SetBool("isHidden", currentMenuState);
        currentMenuState = !currentMenuState;
    }

    public BoosterMenuScript() {
        currentMenuState = false;
    }
}