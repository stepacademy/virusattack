using UnityEngine;
using System.Collections;

public class Virus : MonoBehaviour {

    public float maxHP = 100; 
    public float curHP = 100; 
    public Color MaxDamageColor = Color.red; 
    public Color MinDamageColor = Color.blue; 
    private void Awake()
    {
		GlobalVars.MobList.Add(gameObject); 
		GlobalVars.MobCount++; 
        if (maxHP < 1) maxHP = 1;
    }

    public void ChangeHP(float adjust) 
    {
		curHP -= adjust;
    }

    private void Update()
    {
		gameObject.GetComponent<Renderer>().material.color = Color.Lerp(MaxDamageColor, MinDamageColor, curHP/maxHP);
        //gameObject.renderer.material.color = Color.Lerp(MaxDamageColor, MinDamageColor, curHP / maxHP); //Лерпим цвет моба по заданным в начале цветам. В примере: красный - моб почти полностью убит, синий - целый.
        if (curHP <= 0)
        {
            aivirus mai = gameObject.GetComponent<aivirus>();
			if (mai != null) GlobalVars.PlayerMoney += mai.mobPrice;
            Destroy(gameObject);
        }
    }

    private void OnDestroy(){
		GlobalVars.MobList.Remove(gameObject);
		GlobalVars.MobCount--;
    }
}
