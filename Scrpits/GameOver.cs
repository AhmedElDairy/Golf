using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;
    public Trajectory trajectory;

    private void OnTriggerEnter2D()
    {
        gameManager.timeLeft = 1.0f;
        gameManager.GameLost();  
        

    }   
    

}
