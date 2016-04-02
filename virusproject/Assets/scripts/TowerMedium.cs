using UnityEngine;
using System.Collections;

public class TowerMedium : Tower {

	override public void Start(){
		towerPrice = 100;
		maxHP = 50;
		curHP = maxHP;
		MinDamageColor = Color.gray;
		MaxDamageColor = Color.red;
		defender = true;
		GlobalVars.TowerList.Add(gameObject);
		++GlobalVars.TurretCount;
		GlobalVars.AddTower = true;
	}
}
