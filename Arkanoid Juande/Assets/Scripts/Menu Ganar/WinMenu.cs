using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinMenu : MonoBehaviour
{
    public TextMeshProUGUI pointsText; // Texto para mostrar los puntos obtenidos
    public TextMeshProUGUI highScoreText; // Texto para mostrar la máxima puntuación

    private void Start()
    {
        DisplayScores();
    }

    private void DisplayScores()
    {
        // Obtiene los puntos actuales y la puntuación máxima desde GameData
        int points = GameData.LoadPoints(); // Asumiendo que tienes este método
        int highScore = GameData.LoadHighScore(); // Asumiendo que tienes este método

        // Actualiza el texto de los puntos y la puntuación máxima
        pointsText.text = "Score: " + points;
        highScoreText.text = "High Score: " + highScore;
    }

    public void NextLevel()
    {
        // Carga el índice de la escena guardada
        int currentSceneIndex = GameData.LoadCurrentSceneIndex();
        int nextSceneIndex = currentSceneIndex + 1; // Suma 1 para obtener el siguiente nivel

        // Si el siguiente índice es igual al número de escenas en build settings, regresa al nivel 1
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings - 2)
        {
            nextSceneIndex = 1; // Regresar al menú principal o nivel 1
        }

        // Guarda el nuevo índice de la escena
        GameData.SaveData(GameData.LoadLives(), GameData.LoadPoints(), nextSceneIndex);

        // Carga la siguiente escena
        SceneManager.LoadScene(nextSceneIndex);
    }
}
