using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowHand : MonoBehaviour
{
    public GameObject player; // set by the spawner
    private Vector2 launchDirection;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
        {
            // Calculate direction from spawn to player
            launchDirection = (player.transform.position - transform.position).normalized;

            // Rotate the sprite to face that direction
            float angle = Mathf.Atan2(launchDirection.y, launchDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 180f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move in direction set at spawn
        transform.position += (Vector3)(launchDirection * (GameSpeed.speed * 100) * Time.deltaTime);

        // Destroy after past camera point so it doesn’t stay forever
        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
}
