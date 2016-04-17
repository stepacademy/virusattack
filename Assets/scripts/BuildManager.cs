using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	public GameObject towerSmall;
	public GameObject towerMedium;
	public GameObject towerWall;
	private GameObject tower;
	private Vector3 curPos;
	
	void Update () {
	
		Ray r = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
		RaycastHit rh;
		if (Physics.Raycast (r, out rh)) {
			curPos = rh.point;
		}

		if (tower != null && Input.GetMouseButtonDown (0)) {						
			tower = null;
		}
		if (tower != null) {
			tower.transform.position = new Vector3 (curPos.x, 1, curPos.z);
		}


		switch (GlobalVars.towerSelected) {
		case GlobalVars.ClickState.TowerSmall:
			if (TowerSmall.towerPrice <= GlobalVars.PlayerMoney && tower == null) {
				tower = Instantiate (towerSmall, new Vector3 (curPos.x, 1, curPos.z), Quaternion.identity) as GameObject;
				GlobalVars.PlayerMoney -= TowerSmall.towerPrice;
				GlobalVars.towerSelected = GlobalVars.ClickState.None;

			}
			break;
		case GlobalVars.ClickState.TowerMedium:
			if (TowerMedium.towerPrice <= GlobalVars.PlayerMoney && tower == null) {
				tower = Instantiate (towerMedium, new Vector3 (curPos.x, 1, curPos.z), Quaternion.identity) as GameObject;
				GlobalVars.PlayerMoney -= TowerMedium.towerPrice;
				GlobalVars.towerSelected = GlobalVars.ClickState.None;

			}
			break;
		case GlobalVars.ClickState.TowerWall :
			if(TowerWall.towerPrice <= GlobalVars.PlayerMoney && tower == null){
				tower = Instantiate(towerWall, new Vector3 (curPos.x, 1, curPos.z), Quaternion.identity) as GameObject;
				GlobalVars.PlayerMoney -= TowerWall.towerPrice;
				GlobalVars.towerSelected = GlobalVars.ClickState.None;

			}
			break;
		}
	}
}
