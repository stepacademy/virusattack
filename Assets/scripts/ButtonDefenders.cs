using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonDefenders : MonoBehaviour {

	private void Update()
	{
		if(Input.GetMouseButtonDown(1))
		{
			GlobalVars.towerSelected = GlobalVars.ClickState.None;
		}
	}
	public void SelectedTowerSmall () {
		GlobalVars.towerSelected = GlobalVars.ClickState.TowerSmall;
	}
	public void SelectedTowerMedium () {
		GlobalVars.towerSelected = GlobalVars.ClickState.TowerMedium;
	}
	public void SelectedTowerWall () {
		GlobalVars.towerSelected = GlobalVars.ClickState.TowerWall;
	}
}
