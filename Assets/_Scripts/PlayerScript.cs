using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject explosionPrefab;
	public int shotGap;
	private int time;
	private Transform trans;
	public int health = 20;
	public GameObject hitPrefab;


	private bool canMoveTop = true;
	private bool canMoveBottom = true;
	private bool canMoveLeft = true;
	private bool canMoveRight = true;

	// Use this for initialization
	void Start () {
		trans = gameObject.transform;
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		if (Input.GetAxis ("Horizontal") < 0 && canMoveLeft == true) {
			Debug.Log ("H-");
			transform.Rotate(0, x, 0);
			transform.Translate(0, 0, z);
		} else if (Input.GetAxis ("Horizontal") > 0 && canMoveRight == true) {
			transform.Rotate(0, x, 0);Debug.Log ("H+");
			transform.Translate(0, 0, z);
		} else if (Input.GetAxis ("Vertical") < 0 && canMoveBottom == true) {
			transform.Rotate(0, x, 0);Debug.Log ("V-");
			transform.Translate(0, 0, z);
		} else if (Input.GetAxis ("Vertical") > 0 && canMoveTop == true) {
			transform.Rotate(0, x, 0);Debug.Log ("V+");
			transform.Translate(0, 0, z);
		}

		//this is the axis for jump which is the space bar
		float fire = Input.GetAxis ("Jump");

		if (time < shotGap)
			time++;

		//1st - the object to be made
		//2nd - the placement of the object in reference to the ship
		//3rd - the angle of the spawn
		if (fire > 0) {

			if (time >= shotGap) {
				Instantiate (bulletPrefab, 
					new Vector3(GameObject.Find("SP_MF_Bullet").transform.position.x, GameObject.Find("SP_MF_Bullet").transform.position.y, 
						(GameObject.Find("SP_MF_Bullet").transform.position.z + 0.05f)),
					Quaternion.Euler (90, 0, 0));

				time = 0;
			}
		}

		if (health <= 0) {
			Destroy (this.gameObject);
			Instantiate (explosionPrefab, this.transform.position, this.transform.rotation);
		}
	}

	void OnCollisionEnter(Collision col){

		if(col.gameObject.tag.Equals("Enemy_Bullet")){
			health--;
			Instantiate (hitPrefab, this.transform.position, this.transform.rotation);
			//Debug.Log (health);
		}

		if (col.gameObject.tag.Equals ("Tie")) {
			health--;
			//Debug.Log (health);
		}

		if (col.gameObject.name.Equals ("Wall_Top")) {
			canMoveTop = false;
			Debug.Log ("LockT");
		} else if (col.gameObject.name.Equals ("Wall_Right")) {
			canMoveRight = false;
			Debug.Log ("LockR");
		} else if (col.gameObject.name.Equals ("Wall_Bot")) {
			canMoveBottom = false;
			Debug.Log ("LockB");
		} else if (col.gameObject.name.Equals ("Wall_Left")) {
			canMoveLeft = false;
			Debug.Log ("LockL");
		}
	}

	void OnCollisionExit(Collision col){

		if (col.gameObject.name.Equals ("Wall_Top")) {
			canMoveTop = true;
			Debug.Log ("FreeT");
		} else if (col.gameObject.name.Equals ("Wall_Right")) {
			canMoveRight = true;
			Debug.Log ("FreeR");
		} else if (col.gameObject.name.Equals ("Wall_Bot")) {
			canMoveBottom = true;
			Debug.Log ("FreeB");
		} else if (col.gameObject.name.Equals ("Wall_Left")) {
			canMoveLeft = true ;
			Debug.Log ("FreeL");
		}

	}
}
