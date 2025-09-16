using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameStarted = false;
    public GameObject StartMenu;
    public GameObject DeathMenu;
    public GameObject Player;
    private Vector3 playerStartPos;
    public ScrollLoop[] Environment;

    // Start is called before the first frame update
    void Start()
    {
        // Freeze game upon launch
        Time.timeScale = 0f;

        // Get player position
        playerStartPos = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Start the game if player presses space
        if (!GameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
        else if (CharacterController.dead && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        GameStarted = true;
        StartMenu.SetActive(false);
        Debug.Log("Game Started");
    }

    public void RestartGame()
    {
        StartMenu.SetActive(true);
        GameStarted = false;
        DeathMenu.SetActive(false);
        CharacterController.dead = false;
        Player.transform.position = playerStartPos;

        // Reset Environment
        foreach (ScrollLoop env in Environment)
        {
            env.ResetBackground();
        }
        
        Debug.Log("Game Reset");
    }
}
