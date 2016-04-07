using UnityEngine;
using System.Collections;

public class AIVirus2 : aivirus {

	public override void Start () {
		mobPrice = 5.0f;
		mobSpeed = 2.0f;
		mobAtack = 1.0f;
		damage = 5;
		attackTimer = 0.0f;
		coolDown = 2.0f; 
		mob = transform;
		MobCurrentSpeed = mobSpeed;
	}

}
