using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Scoretext1;
    public Text Scoretext2;
    public GameObject winPoint;
    public int score1;
    public int score2;
    public Timer myTimer;
    public DadsScript dadManager;

    private int ptsAjout = -1;
    private string textPoint = "";


    // Start is called before the first frame update
    void Start()
    {
        Scoretext1.GetComponent<Text>().text = PlayerPrefs.GetInt("score1").ToString();
        Scoretext2.GetComponent<Text>().text = PlayerPrefs.GetInt("score2").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext1.GetComponent<Text>().text = PlayerPrefs.GetInt("score1").ToString();
        Scoretext2.GetComponent<Text>().text = PlayerPrefs.GetInt("score2").ToString();

        if (myTimer.endLevel && ptsAjout == -1)
        {
            if (DadsScript.dadsManager.playerWin == 0)
            {
                ptsAjout = 0;
            }
            else
            {
                ptsAjout = 100;
            }

            textPoint = "+ " + ptsAjout.ToString();
            winPoint.GetComponentInChildren<Text>().text = textPoint;
            winPoint.SetActive(true);

            //Debug.Log("Joueur " + DadsScript.dadsManager.playerWin + " win");
            switch (DadsScript.dadsManager.playerWin)
            {
                case 1:
                    if (ptsAjout != -1)
                    {
                        score1 += PlayerPrefs.GetInt("score1") + ptsAjout;
                        PlayerPrefs.SetInt("score1", score1);
                        Debug.Log(PlayerPrefs.GetInt("score1"));
                    };
                    break;

                case 2:

                    if (ptsAjout != -1)
                    {
                        score2 += PlayerPrefs.GetInt("score2") + ptsAjout;
                        PlayerPrefs.SetInt("score2", score2);
                    };
                    break;

                default:
                    break;
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
        score1 = 0;
        score2 = 0;
    }

    public void AddScore(int nb, int score)
    {
        score += nb;
    }

    public void MinusScore(int nb, int score)
    {
        score -= nb;
    }
}
