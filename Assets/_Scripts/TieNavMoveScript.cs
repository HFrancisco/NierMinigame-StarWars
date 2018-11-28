using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TieNavMoveScript : MonoBehaviour {

	GameObject player;
	public GameObject explosionPrefab;
	public GameObject hitPrefab;
	public int health = 20;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
		if(!player){
			Debug.Log("Make sure your player is tagged!!");
		}
	}
	void Update(){
		GetComponent<UnityEngine.AI.NavMeshAgent>().destination = player.transform.position;
		if (health <= 0) {
			Destroy (this.gameObject);
			Instantiate (explosionPrefab, this.transform.position, this.transform.rotation);
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
