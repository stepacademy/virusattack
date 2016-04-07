using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	public GameObject towerSmall;
	public GameObject towerMedium;
	public GameObject towerWall;
	
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			Ray r = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
			RaycastHit rh;
			if(Physics.Raycast(r, out rh, Mathf.Infinity))
			{
				if(rh.transform.gameObject.tag == "Platform" && !rh.transform.gameObject.GetComponent<Platform>().checkTower)
				{
					switch(GlobalVars.towerSelected)
					{
					case GlobalVars.ClickState.TowerSmall:
						if(TowerSmall.towerPrice <= GlobalVars.PlayerMoney)
						{
							GameObject towerS = Instantiate(towerSmall, new Vector3(rh.transform.position.x, rh.transform.position.y + 0.75f, rh.transform.position.z), Quaternion.identity) as GameObject;
							GlobalVars.PlayerMoney -= TowerSmall.towerPrice;
							rh.transform.gameObject.GetComponent<Platform>().checkTower = true;
							towerS.GetComponent<TowerSmall>().plt = rh.transform.gameObject.GetComponent<Platform>();
						}
						break;
					case GlobalVars.ClickState.TowerMedium :
						if(TowerMedium.towerPrice <= GlobalVars.PlayerMoney)
						{
							GameObject towerM = Instantiate(towerMedium, new Vector3(rh.transform.position.x, rh.transform.position.y + 1.25f, rh.transform.position.z), Quaternion.identity) as GameObject;
							GlobalVars.PlayerMoney -= TowerMedium.towerPrice;
							rh.transform.gameObject.GetComponent<Platform>().checkTower = true;
							towerM.GetComponent<TowerMedium>().plt = rh.transform.gameObject.GetComponent<Platform>();
						}
						break;
					case GlobalVars.ClickState.TowerWall :
						if(TowerWall.towerPrice <= GlobalVars.PlayerMoney)
						{
							GameObject towerW = Instantiate(towerWall, new Vector3(rh.transform.position.x, rh.transform.position.y + 1.25f, rh.transform.position.z), Quaternion.identity) as GameObject;
							GlobalVars.PlayerMoney -= TowerWall.towerPrice;
							rh.transform.gameObject.GetComponent<Platform>().checkTower = true;
							towerW.GetComponent<TowerWall>().plt = rh.transform.gameObject.GetComponent<Platform>();
						}
						break;
					}
				}

			}
		}
	}
}
