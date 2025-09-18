using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Animator anim;
    private bool collected = false;
    public static float soulcounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

	void OnTriggerEnter2D(Collider2D other)
	{
        if (!collected && other.CompareTag("Player"))
        {
            collected = true;
            soulcounter++;
            Debug.Log("collected");

            // Play animation
            if (anim != null)
            {
                anim.SetTrigger("OnPlayerCollision");
                
                // Destroy after animation plays
                float delay = anim != null ? anim.GetCurrentAnimatorStateInfo(0).length : 0.2f;
                Destroy(gameObject, delay);
            }
        }
	}
}
