using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{


    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Game");
    }


}
