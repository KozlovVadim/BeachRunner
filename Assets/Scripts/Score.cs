﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private float score = 0.0f;
    public Text scoreText;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        score += Time.deltaTime;
        scoreText.text = "Points: " + ((int)score).ToString();

	}
}