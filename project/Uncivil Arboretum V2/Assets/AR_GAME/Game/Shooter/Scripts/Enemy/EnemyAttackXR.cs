﻿using UnityEngine;
using System.Collections;

public class EnemyAttackXR : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.


    Animator anim;                              // Reference to the animator component.
    private string animParameterNameForPlayerDead = "PlayerDead";

    GameObject player;                          // Reference to the player GameObject.
    GameObject playerDamageZone;                // Reference to the player's damage zone.
    PlayerHealthXR playerHealth;                  // Reference to the player's health.
    EnemyHealthXR enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.


    void Awake ()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealthXR> ();
        playerDamageZone = playerHealth.playerDamageZone;
        
        enemyHealth = GetComponent<EnemyHealthXR>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        // If the entering collider is the player...
        if(other.gameObject == playerDamageZone)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        // If the exiting collider is the player...
        if(other.gameObject == playerDamageZone)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }


    void Update ()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            // ... attack.
            Attack ();
        }

        // If the player has zero or less health...
        if(playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            anim.SetTrigger (animParameterNameForPlayerDead);
        }
    }


    void Attack ()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if(playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage (attackDamage);
        }
    }
}