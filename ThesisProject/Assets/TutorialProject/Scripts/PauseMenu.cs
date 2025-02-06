using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    bool isPaused;
    GameObject playerObject;
    
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] GameObject pauseStartMenuObject;
    [SerializeField] GameObject menuList;
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        ResetPauseUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPauseGame(InputValue input)
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else if (isPaused)
        {
            UnPauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;

        playerObject.GetComponent<PlayerInput>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenuObject.SetActive(true);
    }

    public void UnPauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;

        playerObject.GetComponent<PlayerInput>().enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseMenuObject.SetActive(false);
        ResetPauseUI();
    }

    public void ResetPauseUI()
    {
        for (int i = 0; i < menuList.transform.childCount; i++)
        {
            menuList.transform.GetChild(i).gameObject.SetActive(false);
        }

        pauseStartMenuObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;    

    }
}
