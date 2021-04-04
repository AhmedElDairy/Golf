using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Text urScore;
    public Text bstScore;

    private void Start()
    {
        urScore.text = "Your Score : " + "\n" + "\n" + Score.scoreValue.ToString();
        bstScore.text = "Best Score : " + "\n" + "\n" + PlayerPrefs.GetInt("High Score").ToString();
    }
    // Start is called before the first frame update
    public void restart()
    {
        if (PlayerPrefs.GetInt("High Score") < Score.scoreValue)
        {
            PlayerPrefs.SetInt("High Score", Score.scoreValue);
        }

        Score.scoreValue = 0;
        SceneManager.LoadScene(0);
    }

   
}
