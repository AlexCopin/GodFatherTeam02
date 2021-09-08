using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Scoretext;
    public int score = 0;
    public Timer myTimer;

    // Start is called before the first frame update
    void Start()
    {
        Scoretext.GetComponent<Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.GetComponent<Text>().text = score.ToString();

        if(myTimer.endLevel)
        {
            if(myTimer.TImeLeft() > 40)
            {
                AddScore(100);
            }
            else if(myTimer.TImeLeft() > 20)
            {
                AddScore(50);
            }
            else if(myTimer.TImeLeft() >= 1)
            {
                AddScore(25);
            }

            myTimer.endLevel = false;
        }
    }


    public void RebootScore()
    {
        score = 0;
    }

    public void AddScore(int nb)
    {
        score += nb;
    }

    public void MinusScore(int nb)
    {
        score -= nb;
    }
}
