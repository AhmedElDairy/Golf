using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NxtLvl : MonoBehaviour
{
    public GameManager gameManager;
    public Score Text;
    public Ball ball;
    public bool win;


    private void OnTriggerEnter2D()
    {
        gameManager.CompleteLevel();
        Score.scoreValue += 10;       
        Destroy(ball);
    }

    public bool Getflag()
    {
        return win;
    }


}
