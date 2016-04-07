using UnityEngine;
using System.Collections;

public class TowerWall : Tower {

	public static float towerPrice = 70;
	
	override public void Awake(){
		maxHP = 100;
		curHP = maxHP;
		MinDamageColor = Color.magenta;
		MaxDamageColor = Color.red;
		defender = true;
		GlobalVars.TowerList.Add(gameObject);
		++GlobalVars.TurretCount;
		GlobalVars.AddTower = true;
	}
}
