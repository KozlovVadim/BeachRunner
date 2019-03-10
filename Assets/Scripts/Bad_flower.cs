using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bad_flower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
            Destroy(gameObject);
    }
}
