using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public float maxHP; 
	public float curHP;
	public Color MaxDamageColor;
	public Color MinDamageColor;
	public bool defender = true;
	public Platform plt;

	virtual public void Awake()
	{
		GlobalVars.TowerList.Add(gameObject);
		++GlobalVars.TurretCount;
		GlobalVars.AddTower = true;

	}
	

	public void Update()
	{
		//gameObject.GetComponent<Renderer>().material.color = Color.Lerp(MaxDamageColor, MinDamageColor, curHP/maxHP);
		//if (curHP <= 0)
		//{
		//	Destroy(gameObject);
		//}
	}

	public void ChangeHP(float adjust)
	{
		curHP -= adjust;
	}

	public void OnDestroy()
	{
		GlobalVars.TowerList.Remove(gameObject);
		GlobalVars.TurretCount--;
	    //plt.checkTower = false;
	}
}
