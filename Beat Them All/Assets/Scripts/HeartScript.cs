﻿using UnityEngine;
using System.Collections;

public class HeartScript : MonoBehaviour {
	
	private HealthBarScript health;

	public AudioClip lifeSound;
	
	// Use this for initialization
	void Start () {
		health = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthBarScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			if(health.curHP > health.maxHP-5)
			{
				health.curHP = health.maxHP;
			}
			else
			{
				health.curHP += 5;
			}

			AudioSource.PlayClipAtPoint (lifeSound, transform.position);

			Destroy(gameObject);
			
		}
	}
	
}
