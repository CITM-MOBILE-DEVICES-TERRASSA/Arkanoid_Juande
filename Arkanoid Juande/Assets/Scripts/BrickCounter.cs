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

    // M�todo para ser llamado cuando un brick es destruido
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
        // Aqu� puedes definir la l�gica para cargar la siguiente escena
        // Por ejemplo, podr�as usar el nombre de la escena o su �ndice
        SceneManager.LoadScene("NextScene"); // Cambia "NextScene" por el nombre real de tu escena
    }
}
