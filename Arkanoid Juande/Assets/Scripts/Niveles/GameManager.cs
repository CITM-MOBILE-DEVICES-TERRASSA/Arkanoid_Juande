using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int points = 0;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highScoreText; // Texto para mostrar la puntuación máxima

    private void Start()
    {
        // Al iniciar el juego, carga las vidas y puntos guardados
        lives = GameData.LoadLives();
        points = GameData.LoadPoints();

        UpdateUI(); // Actualiza la UI al iniciar el juego
        UpdateHighScoreUI(); // Actualiza la UI de la puntuación máxima
    }

    public void NewGame()
    {
        // Reinicia las vidas y puntos, pero conserva la puntuación máxima
        lives = 3; // O el valor que desees
        points = 0; // Reinicia los puntos

        GameData.SaveData(lives, points, SceneManager.GetActiveScene().name); // Guarda los datos y la escena actual

        UpdateUI(); // Actualiza la UI
    }

    public void LoseHealth()
    {
        lives--;
        UpdateUI(); // Actualiza la UI al perder vida

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            // Guardar el nuevo estado de vidas
            GameData.SaveData(lives, points, SceneManager.GetActiveScene().name);
            ResetLevel();
        }
    }

    public void GainPoints(int amount)
    {
        points += amount; // Suma los puntos especificados
        UpdateUI(); // Actualiza la UI al ganar puntos

        // Guardar el nuevo estado de puntos
        GameData.SaveData(lives, points, SceneManager.GetActiveScene().name);
        CheckHighScore(); // Verifica y guarda la puntuación máxima
    }

    public void ResetLevel()
    {
        FindObjectOfType<BallMovement>().ResetBall();
        FindObjectOfType<SliderMovement>().ResetPlayer();
    }

    private void UpdateUI()
    {
        livesText.text = "Vidas: " + lives; // Actualiza el texto de vidas
        pointsText.text = "Puntos: " + points; // Actualiza el texto de puntos
    }

    private void UpdateHighScoreUI()
    {
        int highScore = GameData.LoadHighScore(); // Carga la puntuación máxima
        highScoreText.text = "Máxima Puntuación: " + highScore; // Actualiza el texto de la puntuación máxima
    }

    private void CheckHighScore()
    {
        int highScore = GameData.LoadHighScore(); // Carga la puntuación máxima
        if (points > highScore)
        {
            GameData.SaveHighScore(points); // Actualiza la puntuación máxima
            UpdateHighScoreUI(); // Actualiza el texto de la puntuación máxima
        }
    }

    public void SaveGame()
    {
        GameData.SaveData(lives, points, SceneManager.GetActiveScene().name); // Guardar los datos manualmente si es necesario
    }
}
