using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class aivirus : MonoBehaviour {

    public GameObject target;
    public float mobPrice = 5.0f;
    public float mobSpeed = 1.0f;
    public float mobAtack = 1.0f;
    public float damage = 5;
    public float attackTimer = 0.0f;
    public float coolDown = 2.0f; 

    public float MobCurrentSpeed; 
    public Transform mob; 

    public virtual void Start()
    {
        mob = transform;
        MobCurrentSpeed = mobSpeed;
    }

	public void Update () {
		if (GlobalVars.Basis == null)
			Destroy (gameObject);
		if ((target == null) || GlobalVars.AddTower)
        {
			target = SearchTarget();
        }
		if (target != null) {
				mob.rotation = Quaternion.Lerp (mob.rotation, Quaternion.LookRotation (new Vector3 (target.transform.position.x, 0.0f, target.transform.position.z) - new Vector3 (mob.position.x, 0.0f, mob.position.z)), mobSpeed);
				float distance = Vector3.Distance (target.transform.position, mob.position);
				Vector3 structDirection = (target.transform.position - mob.position).normalized;
			float attackDirection = Vector3.Dot (structDirection, mob.forward);
		if (distance < mobAtack && attackDirection > 0) {
				if (attackTimer > 0)
					attackTimer -= Time.deltaTime;
				if (attackTimer <= 0) {
					Base thp = target.GetComponent<Base>();
					if (thp != null)
						thp.ChangeHP (damage);
					else
					{
						Tower tm = target.GetComponent<Tower>();
						if (tm != null)
							tm.ChangeHP (damage);
					}
					attackTimer = coolDown;
				}
			} else {
				mob.position += mob.forward * MobCurrentSpeed * Time.deltaTime;
			}
		}
		else
			Debug.Log("Base null");
    }

	public GameObject SearchTarget()
    {
        float closestTowerDistance = 0; 
        GameObject nearestTower = null; 
		List<GameObject> sortingTowers = GlobalVars.TowerList;
		GameObject basis = null;
		if(GlobalVars.Basis != null)
			basis = GlobalVars.Basis.gameObject;
		if (basis == null)
			return null;
		foreach (var targetEstimated in sortingTowers) 
        {
			if(targetEstimated.GetComponent<Tower>().defender)
				if ((Vector3.Distance(mob.position, targetEstimated.transform.position) < closestTowerDistance) || closestTowerDistance == 0)
            {
				closestTowerDistance = Vector3.Distance(mob.position, targetEstimated.transform.position);  
				nearestTower = targetEstimated;
            }
        }
		if (closestTowerDistance > Vector3.Distance (mob.position, basis.transform.position)) {
			return basis;
		}
		if (nearestTower == null)
			return basis;
		else
		return nearestTower;
    }

	public void OnDestroy(){
		GlobalVars.MobList.Remove(gameObject);
		GlobalVars.MobCount--;
	}
}
