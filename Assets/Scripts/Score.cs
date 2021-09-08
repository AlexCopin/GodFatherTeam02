using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Scoretext;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Scoretext.GetComponent<Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.GetComponent<Text>().text = score.ToString();
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
