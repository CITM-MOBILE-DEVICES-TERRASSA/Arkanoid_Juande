using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScene : MonoBehaviour
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

    public void ResetGame()
    {
        GameData.ResetData();  // Borra las vidas y puntos guardados
        SceneManager.LoadScene("MainMenu");
    }


}
