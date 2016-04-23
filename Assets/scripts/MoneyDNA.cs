using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[RequireComponent (typeof(Text))]
public class MoneyDNA : MonoBehaviour {

	private Text starText;
	// Use this for initialization
	void Start () {
		starText = GetComponent <Text>();
		starText.text = GlobalVars.PlayerMoney.ToString();
	}

	// Update is called once per frame
	void Update () {
		starText.text = GlobalVars.PlayerMoney.ToString ();
	}

}