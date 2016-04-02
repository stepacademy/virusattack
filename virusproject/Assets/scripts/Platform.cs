using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public bool checkTower;

	// Use this for initialization
	void Start () {
		checkTower = false;
		gameObject.GetComponent<Renderer> ().material.color = Color.black;

	}

}
