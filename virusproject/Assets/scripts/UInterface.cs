using UnityEngine;
using System.Collections;

public class UInterface : MonoBehaviour
{
	
	public Rect buyMenu; 
	public Rect towerSmall;
	public Rect towerMedium; 

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

		playerStats = new Rect(10.0f, 10.0f, 150.0f, 100.0f);
		playerStatsPlayerMoney = new Rect(playerStats.x + 12.5f, playerStats.y + 30.0f, 125.0f, 25.0f);
		
	}
	
	private void Update()
	{
		if(Input.GetMouseButtonDown(1))
		{
			//Destroy(ghost); 
			GlobalVars.towerSelected = GlobalVars.ClickState.None;
		}
//		switch (GlobalVars.mau5tate) 
//		{
//		case GlobalVars.ClickState.Placing: 
//		{
//			if (ghost == null) ghost = Instantiate(plasmaTowerGhost) as GameObject; 
//			else 
//			{
//				Ray scrRay = Camera.main.ScreenPointToRay(Input.mousePosition); 
//				if (Physics.Raycast(scrRay, out hit, Mathf.Infinity, raycastLayers)) 
//				{
//					Quaternion normana = Quaternion.FromToRotation(Vector3.up, hit.normal); 
//					ghost.transform.position = hit.point; 
//					ghost.transform.rotation = normana; 
//					if (Input.GetMouseButtonDown(0) && GlobalVars.PlayerMoney - ghost.GetComponent<aigun>().towerPrice >= 0) 
//					{
//						GameObject tower = Instantiate(plasmaTower, ghost.transform.position, ghost.transform.rotation) as GameObject; 
//						if (tower != null ) GlobalVars.PlayerMoney -= tower.GetComponent<aigun>().towerPrice; 
//						Destroy(ghost); 
//						GlobalVars.mau5tate = GlobalVars.ClickState.Default; 
//					}
//					if(Input.GetMouseButtonDown(1))
//					{
//						Destroy(ghost); 
//						GlobalVars.mau5tate = GlobalVars.ClickState.Default;
//					}
//				}
//			}
//			break;
//		}
//		}
	}
	
	private void OnGUI()
	{
		GUI.Box(buyMenu, "Buying menu"); 
		if (GUI.Button(towerSmall, "Tower Small\n100$"))
		{
			GlobalVars.towerSelected = GlobalVars.ClickState.TowerSmall;

		}
		else if (GUI.Button(towerMedium, "Tower Medium\n100$"))
		{
			GlobalVars.towerSelected = GlobalVars.ClickState.TowerMedium;
		}

		
		GUI.Box(playerStats, "Player Stats");
		GUI.Label(playerStatsPlayerMoney, "Money: " + GlobalVars.PlayerMoney + "$");

	}
}