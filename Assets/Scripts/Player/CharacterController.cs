using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public GameObject DeathMenu;
    public GameObject PlayerUI;
    public static bool dead = false;

    [Header("Statistics")]
    public TMP_Text timeText;
    public TMP_Text distanceText;
    public TMP_Text collectedText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Drag for smooth motion
        rb.drag = 1f;
        rb.gravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * speed, ForceMode2D.Force);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Deadly"))
        {
            Die();
        }
    }

    void Die()
    {
        Time.timeScale = 0f;
        DeathMenu.SetActive(true);
        dead = true;

        // Don't show PlayerUI
        PlayerUI.SetActive(false);

        // Update Statistics
        // Time
        timeText.text = GameSpeed.elapsedTime.ToString("F1") + "s";

        // Distance
        distanceText.text = GameSpeed.distanceTraveled.ToString("F1") + " m";

        // Collected
        collectedText.text = Collectible.soulcounter.ToString();
    }
}
