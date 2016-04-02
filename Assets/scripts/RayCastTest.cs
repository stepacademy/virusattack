using UnityEngine;
using System.Collections;

public class RayCastTest : MonoBehaviour {

	public Transform towerSmall;
	public Transform towerMedium;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
						GameObject towerS = Instantiate(towerSmall, new Vector3(rh.transform.position.x, rh.transform.position.y + 0.75f, rh.transform.position.z), Quaternion.identity) as GameObject;
						rh.transform.gameObject.GetComponent<Platform>().checkTower = true;
						if(towerS != null)
						GlobalVars.PlayerMoney -= towerS.GetComponent<TowerSmall>().towerPrice;
						break;
					case GlobalVars.ClickState.TowerMedium :
						GameObject towerM = Instantiate(towerMedium, new Vector3(rh.transform.position.x, rh.transform.position.y + 1.25f, rh.transform.position.z), Quaternion.identity) as GameObject;
						rh.transform.gameObject.GetComponent<Platform>().checkTower = true;
						if(towerM != null)
						GlobalVars.PlayerMoney -= towerM.GetComponent<TowerMedium>().towerPrice;
						break;
					}
					//IBuildTower bt = new IBuildTower();
				}

					//Instantiate(tower, new Vector3(rh.transform.position.x, rh.transform.position.y + 1.24f, rh.transform.position.z), Quaternion.identity);
				//Destroy(rh.transform.gameObject);
				//rh.transform.gameObject.GetComponent<Renderer>().material.color = Color.black; ///renderer.material.color = Color.black;
			}
		}
	}
}
