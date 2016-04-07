using UnityEngine;
using System.Collections;

public class Virus2 : Virus {

	public override void Start () {
		
		maxHP = 70; 
		curHP = maxHP; 
		MaxDamageColor = Color.red; 
		MinDamageColor = Color.cyan; 
		GlobalVars.MobList.Add(gameObject); 
		GlobalVars.MobCount++; 
	}
}
