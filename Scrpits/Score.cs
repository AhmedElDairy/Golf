using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public static int scoreValue = 0;

    // Update is called once per frame
    void Update()
    {
        ScoreText.text =scoreValue.ToString();
                
    }

   
    }
   
       