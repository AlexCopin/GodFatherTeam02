using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeTarget = 300f;
    private float time = 0;
    public Text timerText;
    public bool isWorking = false;
    public bool rebootTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        time = timeTarget;
        timerText.GetComponent<Text>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);
    }

    // Update is called once per frame
    void Update()
    {
        if(rebootTimer)
        {
            RebootTimer();
        }

        if (isWorking)
        {
            time -= Time.deltaTime;
            
            timerText.GetComponent<Text>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);
        }
        
    }


    public void RebootTimer()
    {
        time = timeTarget;
        rebootTimer = false;
    }
}
