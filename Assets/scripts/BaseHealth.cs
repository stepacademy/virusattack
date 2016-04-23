using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[RequireComponent (typeof(Text))]
public class BaseHealth : MonoBehaviour {

	public GameObject Base;
	private float HealthBase=0f;
	private Text starText;
	// Use this for initialization
	void Start () {
		Base tmp = Base.GetComponent<Base>();
		HealthBase=tmp.maxHP;
		starText = GetComponent <Text>();
		UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateDisplay ();
	}
	private void UpdateDisplay () {
		Base tmp = Base.GetComponent<Base>();
		starText.text = tmp.curHP.ToString();
	}
}



