using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine.InputSystem;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI; // Reference to the game over UI panel.
    //public Text gameOverText; // Reference to the text displaying game over message.
    public Button replayButton; // Reference to the replay button.
    public Button exitButton; // Reference to the exit button.
    public GameObject player;
    public Vector3 targetPosition = new Vector3(-10f, 0f, -360f);
    public InputActionReference replayTrigger;
    public InputActionReference exitTrigger;


    private PlayerHealth playerHealth; // Reference to the player's health script.

    private bool isGameOver = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        gameOverUI.SetActive(false); // Ensure the game over UI is initially hidden.
        replayButton.onClick.AddListener(Replay);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void Update()
    {
        if (!isGameOver && playerHealth.currentHealth <= 0)
        {
            GameOverSet();
            if (replayTrigger.action.IsPressed()) // adding buttton interaction for replaybutton
            {
                Replay();
            }
            if (exitTrigger.action.IsPressed()) 
            {
                ExitGame();
            }
        }
    }

    public void GameOverSet()
    {
        isGameOver = true;

        // Display the game over UI and appropriate message.
        player.transform.position = targetPosition; //player moved to target position /*transform.GetPositionAndRotation(out targetPosition,out Quaternion.ide);*/
        gameOverUI.SetActive(true);
        //gameOverText.text = "Game Over!";

        // You can add buttons for replay and exit in your UI.
    }

    public void Replay()
    {
        // Implement logic to restart the game.reload the current scene by its build index, effectively restarting the scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        // Implement logic to exit the game.
        Application.Quit();
    }
}
