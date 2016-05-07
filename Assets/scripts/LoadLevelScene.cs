using UnityEngine;
using System.Collections;

public class LoadLevelScene : MonoBehaviour {

    public int level;

    public void LoadLevel(int level)
    {
        Application.LoadLevel(level);
    }
}
