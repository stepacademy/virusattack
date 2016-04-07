using UnityEngine;
using System.Collections;

public class Virus1 : Virus {

	public override void Start () {

		maxHP = 100; 
		curHP = maxHP; 
		MaxDamageColor = Color.red; 
		MinDamageColor = Color.blue; 
		GlobalVars.MobList.Add(gameObject); 
		GlobalVars.MobCount++; 
	}

}
