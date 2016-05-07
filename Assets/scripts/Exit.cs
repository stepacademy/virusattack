using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	public void ExitGame()
    {
        Application.CancelQuit();
    }
}
