using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Asigna aquí el Canvas del menú de pausa

    private bool isPaused = false;

    void Update()
    {
        // Detecta si el jugador presiona la tecla Escape
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

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Oculta el menú de pausa
        Time.timeScale = 1f; // Restaura el tiempo del juego
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Muestra el menú de pausa
        Time.timeScale = 0f; // Pausa el tiempo del juego
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Asegúrate de restaurar el tiempo antes de cambiar de escena
        SceneManager.LoadScene("MainMenu"); // Cambia "MainMenu" al nombre real de la escena de tu menú principal
    }
}

