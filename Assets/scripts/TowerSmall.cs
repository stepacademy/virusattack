using UnityEngine;
using System.Collections;

public class TowerSmall : Tower {

	public static float towerPrice = 120;

		override public void Awake () {
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
