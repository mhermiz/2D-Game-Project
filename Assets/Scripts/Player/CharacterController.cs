using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public GameObject DeathMenu;
    public static bool dead = false;

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
        if (Input.GetKey(KeyCode.Space))
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
    }
}
