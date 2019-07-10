using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MultiplayerScenemanager : MonoBehaviour
{

    public Canvas myCanvas;
    public GameObject myObject;
    public bool isPaused;
    public GameObject myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
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
            myPlayer.GetComponent<RotatingThrusters>().enabled = false;
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
            myPlayer.GetComponent<RotatingThrusters>().enabled = true;
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
