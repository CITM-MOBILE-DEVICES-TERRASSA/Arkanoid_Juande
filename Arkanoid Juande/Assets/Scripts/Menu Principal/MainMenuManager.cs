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
        int currentSceneIndex = GameData.LoadCurrentSceneIndex();

        // Verifica si los datos son los predeterminados
        if (savedLives == 3 && savedPoints == 0)
        {
            DisableContinueButton();
        }
        else
        {
            EnableContinueButton(savedLives, savedPoints, currentSceneIndex);
        }

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

    private void EnableContinueButton(int savedLives, int savedPoints, int currentSceneIndex)
    {
        Debug.Log("Habilitando botón de continuar...");

        if (continueButton == null) Debug.LogError("continueButton es null");
        else continueButton.interactable = true;

        if (continueText == null) Debug.LogError("continueText es null");
        else continueText.text = "Continue";

        if (livesText == null) Debug.LogError("livesText es null");
        else livesText.text = "Lives: " + savedLives;

        if (pointsText == null) Debug.LogError("pointsText es null");
        else pointsText.text = "Points: " + savedPoints;

        if (currentSceneText == null) Debug.LogError("currentSceneText es null");
        else currentSceneText.text = "Map: " + currentSceneIndex;
    }


    public void ContinueGame()
    {
        int currentSceneIndex = GameData.LoadCurrentSceneIndex();
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void NewGame()
    {
        GameData.ResetData();
        SceneManager.LoadScene("Level1");
    }
}
