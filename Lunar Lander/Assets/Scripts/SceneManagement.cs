using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public Canvas myCanvas;
    public GameObject myObject;
    public bool isPaused;
    public GameObject myPlayer;

    void Start()
    {
        myCanvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        PauseGame();
        ResumeGame();
    }


    public void LoadSingePlayerScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMultiplayerScene()
    {
        SceneManager.LoadScene("MultiplayerGameScene");
    }

    public void ShowInstructions()
    {
        myObject.gameObject.SetActive(true);
    }

    public void HideInstructions()
    {
        myObject.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        if (Input.GetButton("Pause"))
        {
            myPlayer.GetComponent<Mover>().enabled = false;
            myPlayer.GetComponent<LookAt>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            myObject.gameObject.SetActive(true);
            Time.timeScale = 0f;

            //Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
    }

    public void ResumeGame()
    {
        if (Input.GetButton("Unpause"))
        {
            myPlayer.GetComponent<Mover>().enabled = true;
            myPlayer.GetComponent<LookAt>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            myObject.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadSceneIndex()
    {
        SceneManager.LoadScene(0);
    }
}
