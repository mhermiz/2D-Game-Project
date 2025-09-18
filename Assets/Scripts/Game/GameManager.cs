using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameStarted = false;
    public GameObject StartMenu;
    public GameObject PlayerUI;
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

        // Dont show Death Menu
        DeathMenu.SetActive(false);

        // Dont show PlayerUI
        PlayerUI.SetActive(false);
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
        CharacterController.dead = false;
        Time.timeScale = 1f;
        GameStarted = true;
        StartMenu.SetActive(false);
        PlayerUI.SetActive(true);
        Debug.Log("Game Started");
    }

    public void RestartGame()
    {
        StartMenu.SetActive(true);
        PlayerUI.SetActive(false);
        GameStarted = false;
        DeathMenu.SetActive(false);
        Player.transform.position = playerStartPos;

        // Reset Environment
        foreach (ScrollLoop env in Environment)
        {
            env.ResetBackground();
        }

        // Reset Statistics
        GameSpeed.elapsedTime = 0f;
        GameSpeed.distanceTraveled = 0f;
        Collectible.soulcounter = 0f;

        Debug.Log("Game Reset");
    }
}
