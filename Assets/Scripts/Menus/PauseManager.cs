using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Variables publicas
    public GameObject pausePanel, playerUI;

    // Variables privadas
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        CursorState(false);
    }

    private void Update()
    {
        PauseInput();
    }

    // Funcion para usar el input
    void PauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Funcion para pausar el juego
    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        playerUI.SetActive(false);
        CursorState(true);
        Time.timeScale = 0f;
    }
    
    // Funcion para continuar el juego
    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        playerUI.SetActive(true);
        CursorState(false);
        Time.timeScale = 1f;
    }

    // Funcion para activar y desactivar el cursor
    public void CursorState(bool _state)
    {
        Cursor.visible = _state;
        if (!_state)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
