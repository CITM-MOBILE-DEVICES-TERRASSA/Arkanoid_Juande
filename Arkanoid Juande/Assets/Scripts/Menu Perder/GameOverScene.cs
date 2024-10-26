using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScene : MonoBehaviour
{
    

    public void ResetGame()
    {
        GameData.ResetData();  // Borra las vidas y puntos guardados
        SceneManager.LoadScene("MainMenu");
    }


}
