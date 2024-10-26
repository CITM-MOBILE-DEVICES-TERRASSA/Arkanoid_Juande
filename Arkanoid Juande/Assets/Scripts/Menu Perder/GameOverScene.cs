using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScene : MonoBehaviour
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

    public void ResetGame()
    {
        GameData.ResetData();  // Borra las vidas y puntos guardados
        SceneManager.LoadScene("MainMenu");
    }


}
