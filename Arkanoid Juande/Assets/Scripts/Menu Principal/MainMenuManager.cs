using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;              // Botón de continuar
    public TextMeshProUGUI continueText;       // Texto del botón de continuar
    public TextMeshProUGUI livesText;          // Texto para mostrar las vidas
    public TextMeshProUGUI pointsText;         // Texto para mostrar los puntos
    public TextMeshProUGUI currentSceneText;   // Texto para mostrar el nombre de la escena
    public TextMeshProUGUI highScoreText;      // Texto para mostrar el High Score


    private void Start()
    {
        // Carga las vidas y puntos guardados
        int savedLives = GameData.LoadLives();
        int savedPoints = GameData.LoadPoints();

        // Verifica si los datos son los predeterminados
        if (savedLives == 3 && savedPoints == 0)
        {
            // Desactiva el botón y cambia el color y el texto
            continueButton.interactable = false;
            continueText.text = "No save data";
            ColorBlock colors = continueButton.colors;
            colors.normalColor = Color.gray;
            colors.disabledColor = Color.gray;
            continueButton.colors = colors;
        }
        else
        {
            // Si hay datos, activa el botón y actualiza el texto de vidas y puntos
            continueButton.interactable = true;
            continueText.text = "Continue";
            livesText.text = "Lives: " + savedLives; // Actualiza el texto de vidas
            pointsText.text = "Points: " + savedPoints; // Actualiza el texto de puntos

            // Cargar y mostrar el nombre de la escena donde se quedó el jugador
            string currentScene = GameData.LoadCurrentScene();
            currentSceneText.text = "Map: " + currentScene; // Actualiza el texto con el nombre de la escena
        }

        // Cargar y mostrar el High Score
        int highScore = GameData.LoadHighScore();
        highScoreText.text = "" + highScore; // Actualiza el texto con el High Score
    }

    public void ContinueGame()
    {
        string currentScene = GameData.LoadCurrentScene(); // Carga la escena guardada
        SceneManager.LoadScene(currentScene); // Carga la escena
    }

    public void NewGame()
    {
        GameData.ResetData(); // Reinicia los datos guardados
        SceneManager.LoadScene("Level1");
    }
}
