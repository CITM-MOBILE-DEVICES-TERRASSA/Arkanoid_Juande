using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinMenu : MonoBehaviour
{
    public TextMeshProUGUI pointsText; // Texto para mostrar los puntos obtenidos
    public TextMeshProUGUI highScoreText; // Texto para mostrar la m�xima puntuaci�n

    private void Start()
    {
        DisplayScores();
    }

    private void DisplayScores()
    {
        // Obtiene los puntos actuales y la puntuaci�n m�xima desde GameData
        int points = GameData.LoadPoints(); // Asumiendo que tienes este m�todo
        int highScore = GameData.LoadHighScore(); // Asumiendo que tienes este m�todo

        // Actualiza el texto de los puntos y la puntuaci�n m�xima
        pointsText.text = "Score: " + points;
        highScoreText.text = "High Score: " + highScore;
    }

    public void NextLevel()
    {
        // Carga el �ndice de la escena guardada
        int currentSceneIndex = GameData.LoadCurrentSceneIndex();
        int nextSceneIndex = currentSceneIndex + 1; // Suma 1 para obtener el siguiente nivel

        // Si el siguiente �ndice es igual al n�mero de escenas en build settings, regresa al nivel 1
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings - 2)
        {
            nextSceneIndex = 1; // Regresar al men� principal o nivel 1
        }

        // Guarda el nuevo �ndice de la escena
        GameData.SaveData(GameData.LoadLives(), GameData.LoadPoints(), nextSceneIndex);

        // Carga la siguiente escena
        SceneManager.LoadScene(nextSceneIndex);
    }
}
