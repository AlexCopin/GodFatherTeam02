using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeTarget = 60f;
    private float time = 0;
    public Text timerText;
    public bool isWorking = false;
    public bool endLevel = false;

    // Start is called before the first frame update
    void Start()
    {
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
                endLevel = true;
                isWorking = false;
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
    public void MinusTimer(float t)
    {
        time -= t;
        if(time < 0)
        {
            time = 0;
        }
    }
}
