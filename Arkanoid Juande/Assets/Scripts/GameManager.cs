using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lives = 3;

    public int points = 0;


    public void LoseHealth()
    {
        lives--;

        if(lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        else { ResetLevel(); }

    }

    public void GainPoints()
    {
        points++;

    }

    public void ResetLevel()
    {
        FindObjectOfType<BallMovement>().ResetBall();
        FindObjectOfType<SliderMovement>().ResetPlayer();
    }


}
