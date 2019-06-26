using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public Canvas myCanvas;
    public GameObject myObject;
    public bool isPaused;

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
            myObject.gameObject.SetActive(true);
            Time.timeScale = 0f;

            //Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
    }

    public void ResumeGame()
    {
        if (Input.GetButton("Unpause"))
        {
            myObject.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
