using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class aigun : MonoBehaviour {

	public GameObject curTarget;
	public float towerPrice = 100.0f;
    public float attackDamage = 35.0f;
    public float reloadTimer = 2.5f;
    public float reloadCooldown = 2.5f;
    public Transform turretHead;

    virtual public void Start () {
		turretHead = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
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

	public GameObject SortTargets()
    {
        float closestMobDistance = 0; 
        GameObject nearestmob = null; 
        List<GameObject> sortingMobs = GameObject.FindGameObjectsWithTag("VirusTag").ToList(); 
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
