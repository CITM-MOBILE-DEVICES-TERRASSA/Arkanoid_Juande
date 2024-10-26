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
        LoadGameData();
    }

    private void LoadGameData()
    {
        // Carga las vidas y puntos guardados
        int savedLives = GameData.LoadLives();
        int savedPoints = GameData.LoadPoints();

        // Verifica si los datos son los predeterminados
        if (savedLives == 3 && savedPoints == 0)
        {
            // Desactiva el botón y cambia el color y el texto
            DisableContinueButton();
        }
        else
        {
            // Si hay datos, activa el botón y actualiza el texto de vidas y puntos
            EnableContinueButton(savedLives, savedPoints);
        }

        // Cargar y mostrar el High Score
        int highScore = GameData.LoadHighScore();
        highScoreText.text = "High Score: " + highScore; // Actualiza el texto con el High Score
    }

    private void DisableContinueButton()
    {
        continueButton.interactable = false;
        continueText.text = "No save data";
        ColorBlock colors = continueButton.colors;
        colors.normalColor = Color.gray;
        colors.disabledColor = Color.gray;
        continueButton.colors = colors;
    }

    private void EnableContinueButton(int savedLives, int savedPoints)
    {
        continueButton.interactable = true;
        continueText.text = "Continue";
        livesText.text = "Lives: " + savedLives; // Actualiza el texto de vidas
        pointsText.text = "Points: " + savedPoints; // Actualiza el texto de puntos

        // Cargar y mostrar el índice de la escena donde se quedó el jugador
        int currentSceneIndex = GameData.LoadCurrentSceneIndex();
        string currentScene = SceneManager.GetSceneByBuildIndex(currentSceneIndex).name; // Obtener el nombre de la escena usando el índice
        currentSceneText.text = "Map: " + currentScene; // Actualiza el texto con el nombre de la escena
    }

    public void ContinueGame()
    {
        int currentSceneIndex = GameData.LoadCurrentSceneIndex(); // Carga el índice de la escena guardada
        SceneManager.LoadScene(currentSceneIndex); // Carga la escena usando el índice
    }

    public void NewGame()
    {
        GameData.ResetData(); // Reinicia los datos guardados
        SceneManager.LoadScene("Level1");
    }
}
