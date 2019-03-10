using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    //scoring = faster running
    private float score = 0.0f;
    private int diffLevel = 1;
    private int maxdiffLevel = 15;
    private int scoretonextLevel = 3;

    //Keep point score
    public int points = 0;

    //collider boolean
    private bool isDead = false;
    public DeathScreen DeathMenu;


	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        // collider check if player hits
        if (isDead)
            return;


        //move the character
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }


        // X
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        // Y
        moveVector.y = verticalVelocity;

        // Z 
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

        //keep score and move character faster
        score += Time.deltaTime * diffLevel;

        if (score >= scoretonextLevel)
            Levelup();

        

	}

    void Levelup()
    {
        if (diffLevel == maxdiffLevel)
            return;
        scoretonextLevel *= 2;
        diffLevel++;

        SetSpeed(diffLevel);

        Debug.Log(diffLevel);
    }

    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    // if collided, player will die
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
            DieOnHit();
        //Destroy(GameObject.FindWithTag("flower"));
        
    }

    private void DieOnHit ()
    {
        isDead = true;
        DeathMenu.ToggleDeathMenu(score);
    }
    

}
