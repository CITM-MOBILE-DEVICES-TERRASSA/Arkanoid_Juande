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
        // Al iniciar el juego, carga las vidas y puntos guardados
        lives = GameData.LoadLives();
        points = GameData.LoadPoints();

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
            // Guardar el nuevo estado de vidas
            GameData.SaveData(lives, points);
            ResetLevel();
        }
    }

    public void GainPoints(int amount)
    {
        points += amount; // Suma los puntos especificados
        UpdateUI(); // Actualiza la UI al ganar puntos

        // Guardar el nuevo estado de puntos
        GameData.SaveData(lives, points);
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

    public void SaveGame()
    {
        GameData.SaveData(lives, points); // Guardar los datos manualmente si es necesario
    }
}
