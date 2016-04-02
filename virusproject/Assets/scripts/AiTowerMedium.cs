using UnityEngine;
using System.Collections;

public class AiTowerMedium : aigun {

	override public void Start () {
		turretHead = this.transform;
		towerPrice = 100.0f;
		attackDamage = 100.0f;
		reloadTimer = 5f;
		reloadCooldown = 5f;
	}
}
