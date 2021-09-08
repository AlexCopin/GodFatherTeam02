using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Scoretext;
    public GameObject winPoint;
    public int score = 0;
    public Timer myTimer;

    private int ptsAjout = -1;
    private string textPoint = "";


    // Start is called before the first frame update
    void Start()
    {
        Scoretext.GetComponent<Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.GetComponent<Text>().text = score.ToString();

        if(myTimer.endLevel && ptsAjout == -1)
        {
            if (myTimer.TImeLeft() > 40)
            {
                ptsAjout = 100;
            }
            else if(myTimer.TImeLeft() > 20)
            {
                ptsAjout = 50;
            }
            else if(myTimer.TImeLeft() >= 1)
            {
                ptsAjout = 25;
            }
            textPoint = "+ " + ptsAjout.ToString();
            winPoint.GetComponentInChildren<Text>().text = textPoint;
            winPoint.SetActive(true);


            if(ptsAjout != -1)
            {
                score += ptsAjout;
            }
        }
        else if(!myTimer.endLevel)
        {
            winPoint.SetActive(false);
            ptsAjout = -1;
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
