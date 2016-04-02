using UnityEngine;
using System.Collections;

public class AiTowerSmall : aigun {

	// Use this for initialization
	override public void Start () {
		turretHead = this.transform;
		towerPrice = 100.0f;
		attackDamage = 35.0f;
		reloadTimer = 2.5f;
		reloadCooldown = 2.5f;
	}

}
