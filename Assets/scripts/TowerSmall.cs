using UnityEngine;
using System.Collections;

public class TowerSmall : Tower {

	// Use this for initialization
	override public void Start () {
	
		towerPrice = 100;
		maxHP = 100;
		curHP = maxHP;
		MinDamageColor = Color.yellow;
		MaxDamageColor = Color.red;
		defender = false;
		GlobalVars.TowerList.Add(gameObject);
		++GlobalVars.TurretCount;
		GlobalVars.AddTower = true;
	}

}
