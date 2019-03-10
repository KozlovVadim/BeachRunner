using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {

        gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleDeathMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = "Points: " + ((int)score).ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
