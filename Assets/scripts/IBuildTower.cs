using UnityEngine;
using System.Collections;

public class IBuildTower{

	Rect menu;
	Rect towerSmall;
	Rect towerMedium;


	// Use this for initialization
	void Start () {
	
		menu = new Rect(Screen.width - Screen.width/2, Screen.height - Screen.height/2, 175.0f, 100.0f);
		towerSmall = new Rect (menu.x + 10, menu.y + 10, 100, 50);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnGUI()
	{
		GUI.Box(menu, "Build menu"); 
		if (GUI.Button(towerSmall, "Tower 1\n100$"))
		{
			//GlobalVars.mau5tate = GlobalVars.ClickState.Placing;
		}
		
		
//		GUI.Box(playerStats, "Player Stats");
//		GUI.Label(playerStatsPlayerMoney, "Money: " + GlobalVars.PlayerMoney + "$");
		
	}
}
