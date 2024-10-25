using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickCounter : MonoBehaviour
{
    public List<GameObject> bricks; // Lista para almacenar los bricks

    private void Start()
    {
        // Encuentra todos los objetos con el tag "Brick" y los agrega a la lista
        bricks = new List<GameObject>(GameObject.FindGameObjectsWithTag("Brick"));
        Debug.Log("Bricks contados: " + bricks.Count);
    }

    // Método para ser llamado cuando un brick es destruido
    public void BrickDestroyed()
    {
        bricks.RemoveAt(0); // Remueve el brick destruido

        // Comprobar si quedan bricks
        if (bricks.Count == 0)
        {
            LoadNextScene(); // Carga la nueva escena si no quedan bricks
        }
    }

    private void LoadNextScene()
    {
        // Aquí puedes definir la lógica para cargar la siguiente escena
        // Por ejemplo, podrías usar el nombre de la escena o su índice
        SceneManager.LoadScene("NextScene"); // Cambia "NextScene" por el nombre real de tu escena
    }
}
