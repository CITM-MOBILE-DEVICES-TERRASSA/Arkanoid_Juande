using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickCounter : MonoBehaviour
{
    private int totalBricks; // Contador para los bricks totales
    private int bricksDestroyed; // Contador para los bricks destruidos

    private void Start()
    {
        // Encuentra todos los objetos con el tag "Brick" y cuenta cuántos hay
        GameObject[] brickObjects = GameObject.FindGameObjectsWithTag("Brick");
        totalBricks = brickObjects.Length;
        bricksDestroyed = 0; // Inicializa el contador de bricks destruidos
        Debug.Log("Bricks contados: " + totalBricks);
    }

    // Método que debe ser llamado cuando un brick es destruido
    public void BrickDestroyed()
    {
        bricksDestroyed++; // Incrementa el contador de bricks destruidos
        Debug.Log("Bricks destruidos: " + bricksDestroyed);

        // Comprobar si todos los bricks han sido destruidos
        if (bricksDestroyed >= totalBricks)
        {
            LoadWinMenu(); // Carga el WinMenu si no quedan bricks
        }
    }

    private void LoadWinMenu()
    {
        // Guarda el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameData.SaveData(GameData.LoadLives(), GameData.LoadPoints(), currentSceneIndex); // Guarda datos

        // Carga el WinMenu
        SceneManager.LoadScene("WinMenu");
    }
}
