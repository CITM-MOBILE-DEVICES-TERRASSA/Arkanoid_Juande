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

    private void Start()
    {
        UpdateUI(); // Actualiza la UI al iniciar el juego
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
            ResetLevel();
        }
    }

    public void GainPoints(int amount)
    {
        points += amount; // Suma los puntos especificados
        UpdateUI(); // Actualiza la UI al ganar puntos
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
}
