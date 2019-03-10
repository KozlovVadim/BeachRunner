using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform lookat;
    private Vector3 startoffset;
    private Vector3 moveVector;

	// Use this for initialization
	void Start () {
        lookat = GameObject.FindGameObjectWithTag("Player").transform;
        startoffset = transform.position - lookat.position;

    }
	
	// Update is called once per frame
	void Update () {
        moveVector = lookat.position + startoffset;

        // X
        moveVector.x = 0;

        // Y 
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        transform.position = moveVector;
	}
}
