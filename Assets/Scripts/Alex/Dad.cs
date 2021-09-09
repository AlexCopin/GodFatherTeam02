using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dad : MonoBehaviour
{
    
    public bool realDad;
    public float speed;
    public Color color;
    //public int index;
    public Sprite body;
    float marginSide;
    float marginTopBot;
    enum InputDad{
        JoystickButton0,
        JoystickButton1,
        JoystickButton2,
        JoystickButton3
    }

    private void Start()
    {
        speed = Random.Range(1, 5);
        marginSide = DadsScript.dadsManager.marginSides * Screen.width;
        marginTopBot = DadsScript.dadsManager.marginTop * Screen.height;
        //GetComponent<SpriteRenderer>().sprite = body;
        GetComponent<SpriteRenderer>().color = color;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(marginSide, Screen.width- marginSide), Random.Range(marginTopBot, Screen.height- marginTopBot),0));
    }

    public  void ChangePos(List<Dad> dads)
    {
        for(int i = 0; i < dads.Count; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            if (this != dads[i] && Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(dads[i].transform.position.x, dads[i].transform.position.y)) < 1f)
            {
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(marginSide, Screen.width - marginSide), Random.Range(marginTopBot, Screen.height - marginTopBot), 0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(marginSide, Screen.width - marginSide), Random.Range(marginTopBot, Screen.height - marginTopBot), 0)).y, 0);
            }
        }
    }
}
