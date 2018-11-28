﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFBulletScript : MonoBehaviour {

	public float speed;
	public GameObject player;
	private Transform trans;

	void Start () {
		trans = transform;
		player = GameObject.Find("MilleniumFalcon");

		trans.forward = player.transform.forward;

		gameObject.GetComponent<Rigidbody> ().velocity = trans.forward * speed;	
	}

	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name.Equals("TieFighter_TopRight") || col.gameObject.name.Equals("TieFighter_TopLeft") ||
			col.gameObject.name.Equals("TieFighter_BottomRight") || col.gameObject.name.Equals("TieFighter_BottomLeft")){

			Destroy (this.gameObject);
		}

		if(col.gameObject.name.Equals("Wall_Top") || col.gameObject.name.Equals("Wall_Right") ||
			col.gameObject.name.Equals("Wall_Left") || col.gameObject.name.Equals("Wall_Bot") || 
			col.gameObject.name.Equals("DeathStar") || col.gameObject.tag.Equals("Player_Bullet") || 
			col.gameObject.tag.Equals("Enemy_Bullet")){

			Destroy(this.gameObject);
		}

	}
}
