using UnityEngine;
using System.Collections;

public class AiTowerSmall : AiGun {

	override public void Start () {
		turretHead = this.transform;
		attackDamage = 35.0f;
		reloadTimer = 2.5f;
		reloadCooldown = 2.5f;
		closestMobDistance = 0f;
	}

}
