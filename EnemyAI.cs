using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 100f;
    public GameObject gameOverScreen;
    
    private bool playerDetected = false;

    private void Update()
    {
        if (!playerDetected)
        {
            // Calculate the distance between the enemy and the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // If player is within detection range, eliminate player and show game over screen
            if (distanceToPlayer <= detectionRange)
            {
                EliminatePlayer();
            }
        }
    }

    private void EliminatePlayer()
    {
        playerDetected = true;
        
        // Display game over screen
        gameOverScreen.SetActive(true);

        // Optionally, you can add more actions here like playing a sound, showing animations, etc.

        // Disable the enemy's collider and renderer to prevent further interactions
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
        
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }
}
