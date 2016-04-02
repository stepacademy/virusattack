using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Vector3.Distance(target.transform.position, transform.position) < 3f)
            Debug.Log("Sphere here");
    }

    void OnTriggerEnter(Collider myTrigger)
    {

        if (myTrigger.gameObject.name == "Sphere")
        {
           // Debug.Log("Sphere went through");
            Destroy(gameObject, .5f);
        }
    }
    }
