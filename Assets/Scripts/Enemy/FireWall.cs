using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    private Vector2 launchDirection;

    // Start is called before the first frame update
    void Start()
    {
        // Always move left
        launchDirection = Vector2.left;
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
