using UnityEngine;
using System.Collections;

public class PlatformBarricade : MonoBehaviour {

	// Use this for initialization
	public GameObject TowerBarricade;
	private GameObject TB;
	void Awake() {

		TB = Instantiate (TowerBarricade, new Vector3(this.transform.position.x, 1, this.transform.position.z), Quaternion.identity) as GameObject;

	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
