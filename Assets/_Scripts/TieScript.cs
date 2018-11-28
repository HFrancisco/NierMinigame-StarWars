using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieScript : MonoBehaviour {

	//The target player
	public Transform player;
	public int health = 20;
	public GameObject explosionPrefab;
	public GameObject hitPrefab;

	//In what time will the enemy complete the journey between its position and the players position
	public float smoothTime = 5.0f;

	//Vector3 used to store the velocity of the enemy
	private Vector3 smoothVelocity = Vector3.zero;

	//Call every frame
	void Update()
	{
		if (GameObject.FindGameObjectsWithTag ("Player").Length > 0) {

			//Look at the player
			transform.LookAt(player);

			//Move the enemy towards the player with smoothdamp
			transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);

			if (health <= 0) {
				Destroy (this.gameObject);
				Instantiate (explosionPrefab, this.transform.position, this.transform.rotation);
			}

		}
	}

	void OnCollisionEnter(Collision col){

		if(col.gameObject.tag.Equals("Player_Bullet")){
			health--;
			Instantiate (hitPrefab, this.transform.position, this.transform.rotation);
			//Debug.Log (health);
		}
	}
}
