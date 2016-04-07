using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalVars : MonoBehaviour {

    public static List<GameObject> MobList = new List<GameObject>();
    public static int MobCount = 0;

	public static Base Basis = null;

    public static List<GameObject> TowerList = new List<GameObject>();
    public static int TurretCount = 0;
	public static bool AddTower = false;

    public static float PlayerMoney = 200.0f;

	public static ClickState towerSelected = ClickState.None; 
	
	public enum ClickState 
	{
		TowerSmall,
		TowerMedium,
		TowerWall,
		None
	}

}
