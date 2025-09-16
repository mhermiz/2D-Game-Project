using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public static float speed;

    [Header("Speed Settings")]
    public float startSpeed = 3f;      // starting speed
    public float maxSpeed = 12f;       // top speed
    public float timeToMax = 120f;     // how many seconds it takes to reach max speed

    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Progress ratio (0 → 1) over the course of timeToMax seconds
        float t = Mathf.Clamp01(elapsedTime / timeToMax);

        // Smooth ramp using Lerp
        speed = Mathf.Lerp(startSpeed, maxSpeed, t);
    }
}
