using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public bool checkTower;

	void Start () {
		checkTower = false;
		gameObject.GetComponent<Renderer> ().material.color = Color.black;

	}

}
