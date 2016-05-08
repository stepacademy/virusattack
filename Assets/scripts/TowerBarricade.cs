using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TowerBarricade : MonoBehaviour {

	float MobDistance;
	public Transform turretHead;


	void Start () {
		turretHead = this.transform;
		MobDistance = 6f;
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision ObjColl){

		if (ObjColl.gameObject.tag == "VirusTag") {

			gameObject.transform.localScale = new Vector3 (this.transform.localScale.x + 6, this.transform.localScale.y + 6,
				this.transform.localScale.z + 6);
			SortTargets ();

		}
	}


	public void SortTargets()
	{
		
		List<GameObject> sortingMobs = GlobalVars.MobList;

		foreach (var everyTarget in sortingMobs )
		{			
			if ( (Vector3.Distance(everyTarget.transform.position, turretHead.position)) <  MobDistance){
				Destroy (everyTarget);
			}
		}

		Destroy (gameObject, 2f);

	}
}
