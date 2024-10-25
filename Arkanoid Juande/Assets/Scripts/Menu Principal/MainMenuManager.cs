using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ContinueGame()
    {
        // Cargar datos guardados y empezar el juego
        SceneManager.LoadScene("Game"); // Carga la escena principal del juego
    }

    public void NewGame()
    {
        GameData.ResetData(); // Reinicia los datos guardados
        SceneManager.LoadScene("Game");
    }
}
