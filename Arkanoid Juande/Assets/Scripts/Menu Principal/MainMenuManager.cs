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
            continueText.text = "Sin Datos";
            ColorBlock colors = continueButton.colors;
            colors.normalColor = Color.gray;
            colors.disabledColor = Color.gray;
            continueButton.colors = colors;
        }
        else
        {
            // Si hay datos, activa el botón y actualiza el texto de vidas y puntos
            continueButton.interactable = true;
            continueText.text = "Continuar";
            livesText.text = "Vidas: " + savedLives; // Actualiza el texto de vidas
            pointsText.text = "Puntos: " + savedPoints; // Actualiza el texto de puntos
        }
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Game"); // Carga la escena principal del juego
    }

    public void NewGame()
    {
        GameData.ResetData(); // Reinicia los datos guardados
        SceneManager.LoadScene("Game");
    }
}
