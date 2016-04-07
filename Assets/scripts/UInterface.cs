using UnityEngine;
using System.Collections;

public class UInterface : MonoBehaviour
{
	
	public Rect buyMenu; 
	public Rect towerSmall;
	public Rect towerMedium; 
	public Rect towerWall; 
	public Rect playerStats; 
	public Rect playerStatsPlayerMoney; 
	
	public GameObject plasmaTower;
	public GameObject plasmaTowerGhost; 

	private RaycastHit hit;
	public LayerMask raycastLayers = 1; 
	
	//private GameObject ghost;
	private void Awake()
	{
		
		buyMenu = new Rect(Screen.width - 185.0f, 10.0f, 175.0f, Screen.height - 100.0f);  
		towerSmall = new Rect(buyMenu.x + 12.5f, buyMenu.y + 30.0f, 150.0f, 50.0f);
		towerMedium = new Rect(towerSmall.x, buyMenu.y + 90.0f, 150.0f, 50.0f);
		towerWall = new Rect(towerSmall.x, buyMenu.y + 150.0f, 150.0f, 50.0f);

		playerStats = new Rect(10.0f, 10.0f, 150.0f, 100.0f);
		playerStatsPlayerMoney = new Rect(playerStats.x + 12.5f, playerStats.y + 30.0f, 125.0f, 25.0f);
		
	}
	
	private void Update()
	{
		if(Input.GetMouseButtonDown(1))
		{
			GlobalVars.towerSelected = GlobalVars.ClickState.None;
		}
	}
	
	private void OnGUI()
	{
		GUI.Box(buyMenu, "Buying menu"); 
		if (GUI.Button(towerSmall, "Tower Small\n" + TowerSmall.towerPrice.ToString() + " ДНК"))
		{
			GlobalVars.towerSelected = GlobalVars.ClickState.TowerSmall;

		}
		else if (GUI.Button(towerMedium, "Tower Medium\n" + TowerMedium.towerPrice.ToString() + " ДНК"))
		{
			GlobalVars.towerSelected = GlobalVars.ClickState.TowerMedium;
		}
		else if (GUI.Button(towerWall, "Tower Wall\n" + TowerWall.towerPrice.ToString() + " ДНК"))
		{
			GlobalVars.towerSelected = GlobalVars.ClickState.TowerWall;
		}

		
		GUI.Box(playerStats, "Player Stats");
		GUI.Label(playerStatsPlayerMoney, "ДНК: " + GlobalVars.PlayerMoney);

	}
}