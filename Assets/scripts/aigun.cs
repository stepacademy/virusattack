using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class aigun : MonoBehaviour {

	public GameObject curTarget;
	public float attackDamage;
    public float reloadTimer;
    public float reloadCooldown;
    public Transform turretHead;

	public float closestMobDistance = 0; 

    virtual public void Start () {
		turretHead = this.transform;
    }
	
	virtual public void Update () {
        if (curTarget != null) 
        {
            if (reloadTimer > 0) reloadTimer -= Time.deltaTime; 
            if (reloadTimer < 0) reloadTimer = 0;
            if (reloadTimer == 0) 
            {
				Virus vrs = curTarget.GetComponent<Virus>();
				//float distance = Vector3.Distance(turretHead.position, curTarget.transform.position); 
				if (vrs != null)
					vrs.ChangeHP(attackDamage);
                reloadTimer = reloadCooldown;
            }
        }
        else 
        {
            curTarget = SortTargets(); 
        }

    }

	virtual public GameObject SortTargets()
    {
        GameObject nearestmob = null; 
		List<GameObject> sortingMobs = GlobalVars.MobList;
        foreach (var everyTarget in sortingMobs)
        {
			if ((Vector3.Distance(everyTarget.transform.position, turretHead.position) < closestMobDistance) || closestMobDistance == 0)
            {
				closestMobDistance = Vector3.Distance(everyTarget.transform.position, turretHead.position);
                nearestmob = everyTarget;
            }
        }
        return nearestmob;
    }
}
