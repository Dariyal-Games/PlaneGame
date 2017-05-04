using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class playerMovementScript : MonoBehaviour {
	//float speed;
	public GameObject Bullet;
	public GameObject BulletPosition;
	Rigidbody2D myBody;
	public float speed;
	public float angularSpeed;
	public Button ShootButton;
	public float coolDown = 1;
	public float coolDownTimer;

	// Use this for initialization
	void Start () {
		speed = 1;
		myBody = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		myBody.AddForce(transform.up*speed);
		Debug.Log(CrossPlatformInputManager.GetAxisRaw("Horizontal"));
	
		myBody.rotation -= CrossPlatformInputManager.GetAxis("Horizontal")*angularSpeed*Time.deltaTime;

		//Shoot cooldown
		if (coolDownTimer > 0) 
		{
			coolDownTimer -= Time.deltaTime;
		}
		if (coolDownTimer < 0)
		{
			coolDownTimer = 0;
		}
		if (CrossPlatformInputManager.GetButtonDown ("Shoot") && coolDownTimer == 0) {
			TaskOnClick ();
			coolDownTimer = coolDown;
			Debug.Log ("hii");
		}

	}
	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		GameObject bullet01 = (GameObject)Instantiate (Bullet);
		bullet01.transform.position = BulletPosition.transform.position;


	}
	

}
