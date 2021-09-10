using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timeTarget = 60f;
    public float timeBeforeNextLevel = 2f;
    private float time = 0;
    public Text timerText;
    public bool isWorking = false;
    public bool endLevel = false;
    public float deducedTime = 5;
    public Image goodDadCanvas;

    private float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        goodDadCanvas = GameObject.Find("Good_Dad").GetComponent<Image>();
        time = timeTarget;
        timerText.GetComponent<Text>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);
    }

    // Update is called once per frame
    void Update()
    {

        if (isWorking)
        {
            time -= Time.deltaTime;
            
            timerText.GetComponent<Text>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);

            if(time<=0)
            {
                time = 0;
                timerText.GetComponent<Text>().text = "0:00";
                endLevel = true;
                isWorking = false;
                if (t < timeBeforeNextLevel)
                {
                    t += Time.deltaTime;
                }
                else
                {
                    t = 0;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }

        }
        else
        {
            if(t< timeBeforeNextLevel)
            {
                if(t<1 && goodDadCanvas.canvasRenderer.GetAlpha() != 0)
                {
                    goodDadCanvas.CrossFadeAlpha(1 - t, 0, false);
                }
                else
                {
                    goodDadCanvas.canvasRenderer.SetAlpha(0f);
                }
                t += Time.deltaTime;
            }
            else
            {
                t = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
           
        }
        

    }

    //Reboot le timer
    public void RebootTimer()
    {
        time = timeTarget;
        endLevel = false;
    }

    //Active le timer
    public void ActiveTimer()
    {
        isWorking = true;
        endLevel = false;
    }

    //Met pause au timer
    public void PauseTimer()
    {
        isWorking = false;
    }

    //Met fin au timer quand un niveau se termine
    public void EndLevel()
    {
        PauseTimer();
        endLevel = true;
    }

    //Renvoie le temps restant
    public float TImeLeft()
    {
        return time;
    }

    //Renvoie si le timer est actif
    public bool TimerIsWorking()
    {
        return isWorking;
    }

    //Retire du temps
    public void MinusTimer()
    {
        time -= deducedTime;
        if(time < 0)
        {
            time = 0;
        }
    }
}
