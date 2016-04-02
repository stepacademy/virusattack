using UnityEngine;
using System.Collections;

public class TurretHP : MonoBehaviour {

    public float maxHP = 100; 
    public float curHP = 100; 
	public Color MaxDamageColor = Color.red; 
	public Color MinDamageColor = Color.green;
    //private GlobalVars gv;

    private void Awake()
    {
		//GlobalVars = GameObject.Find("GlobalVars").GetComponent<GlobalVars>(); 
        GlobalVars.TowerList.Add(gameObject);
		GlobalVars.TurretCount++;
        if (maxHP < 1) maxHP = 1;
    }

    public void ChangeHP(float adjust)
    {
		curHP -= adjust;
    }

    private void Update()
    {
		gameObject.GetComponent<Renderer>().material.color = Color.Lerp(MaxDamageColor, MinDamageColor, curHP/maxHP);
        if (curHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
		GlobalVars.TowerList.Remove(gameObject);
		GlobalVars.TurretCount--;
    }
}
