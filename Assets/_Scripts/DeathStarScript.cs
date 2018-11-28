using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathStarScript : MonoBehaviour {
	
	public GameObject bulletPrefab;
	public int shotGap;
	private int time;
	private Transform trans;
	public Transform player;
	public int health = 40;
	public GameObject explosionPrefab;
	public Text text;
	public GameObject hitPrefab;


	private GameObject[] tieCount;

	// Use this for initialization
	void Start () {
		trans = gameObject.transform;
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.FindGameObjectsWithTag ("Player").Length > 0) {

			transform.LookAt (player);

			tieCount = GameObject.FindGameObjectsWithTag ("Tie");


			if (time < shotGap)
				time++;

			if (time >= shotGap) {
				Instantiate (bulletPrefab, 
					new Vector3 (GameObject.Find ("SP_DS_Bullet").transform.position.x, GameObject.Find ("SP_DS_Bullet").transform.position.y, 
						(GameObject.Find ("SP_DS_Bullet").transform.position.z + 0.05f)),
					Quaternion.Euler (90, 0, 0));

				time = 0;
			}

			if (health <= 0) {
				Destroy (this.gameObject);
				Instantiate (explosionPrefab, this.transform.position, this.transform.rotation);
				text.text = "Well done! The Empire has fallen!";
			}

			if (tieCount.Length <= 0)
				text.text = "The shields are down! \n Now's your chance!";
		}
		
	}

	void OnCollisionEnter(Collision col){

		if(col.gameObject.tag.Equals("Player_Bullet")){

			if (tieCount.Length <= 0) {
				health--;
				Instantiate (hitPrefab, this.transform.position, this.transform.rotation);
			}

		}
	}
}
