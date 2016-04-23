using UnityEngine;
using System.Collections;

public class Virus : MonoBehaviour {

    public float maxHP; 
    public float curHP; 
    public Color MaxDamageColor; 
    public Color MinDamageColor; 

    public virtual void Start()
    {
		maxHP = 100; 
		curHP = maxHP; 
		MaxDamageColor = Color.red; 
		MinDamageColor = Color.blue; 
		GlobalVars.MobList.Add(gameObject); 
		GlobalVars.MobCount++; 
    }

    public void ChangeHP(float adjust) 
    {
		curHP -= adjust;
    }

    public void Update()
    {
		//gameObject.GetComponent<Renderer>().material.color = Color.Lerp(MaxDamageColor, MinDamageColor, curHP/maxHP);
        //gameObject.renderer.material.color = Color.Lerp(MaxDamageColor, MinDamageColor, curHP / maxHP); //Лерпим цвет моба по заданным в начале цветам. В примере: красный - моб почти полностью убит, синий - целый.
        if (curHP <= 0)
        {
            aivirus mai = gameObject.GetComponent<aivirus>();
			if (mai != null) GlobalVars.PlayerMoney += mai.mobPrice;
            Destroy(gameObject);
        }
    }

	public void OnDestroy(){
		GlobalVars.MobList.Remove(gameObject);
		GlobalVars.MobCount--;
    }
}
