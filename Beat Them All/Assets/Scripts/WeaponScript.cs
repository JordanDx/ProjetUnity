﻿using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
    //Shot variables
    public Transform shotPrefab; // Projectile prefab for shooting
    public float shootingRate; // Cooldown in seconds between two shots

    //Audio
	public AudioClip projectileSound;

    //--------------------------------
    // 2 - Cooldown
    //--------------------------------
    private float shootCooldown;

    // Is the weapon ready to create a new projectile?
    public bool CanAttack
    {
        get { return shootCooldown <= 0f; }
    }

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    
    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    /// <summary>
    /// Create a new projectile if possible
    /// </summary>
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
			AudioSource.PlayClipAtPoint (projectileSound, transform.position);
            shootCooldown = shootingRate;

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            // The is enemy property
            ShotScriptSphere shot = shotTransform.gameObject.GetComponent<ShotScriptSphere>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it
            MoveShotScript move = shotTransform.gameObject.GetComponent<MoveShotScript>();
            if (move != null)
            {
                move.direction = transform.right; // towards in 2D space is the right of the sprite
            }
        }
    }
}
