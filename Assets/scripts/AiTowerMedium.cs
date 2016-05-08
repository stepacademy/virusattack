using UnityEngine;
using System.Collections;

public class AiTowerMedium : aigun {

	override public void Start () {
		turretHead = this.transform;
		attackDamage = 100.0f;
		reloadTimer = 5f;
		reloadCooldown = 5f;
		closestMobDistance = 0f;
	}
}
