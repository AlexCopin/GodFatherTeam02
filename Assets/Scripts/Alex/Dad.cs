using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dad : MonoBehaviour
{
    [Header("Movement")]
    public Vector2 speedRange;
    public float speed;
    bool goingBack;
    public Vector3 direction;
    public bool inLevel = true;
    public bool changeDirection;
    float marginSide;
    float marginTopBot;
    [Header("DadScript")]
    public bool realDad;
    public int index;

        
    private void Start()
    {
        speed = Random.Range(speedRange.x, speedRange.y);
        marginSide = DadsScript.dadsManager.marginSides * Screen.width;
        marginTopBot = DadsScript.dadsManager.marginTop * Screen.height;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(marginSide, Screen.width- marginSide), Random.Range(marginTopBot, Screen.height- marginTopBot),0));
    }

    void Update()
    {
        direction.z = 0;
        if (!changeDirection && inLevel)
        {
            StartCoroutine(ChangeDirections());
        }
        if (!inLevel && !goingBack)
        {
            goingBack = true;
            Vector3 dirGoingBack = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(marginSide, Screen.width - marginSide), Random.Range(marginTopBot, Screen.height - marginTopBot), 0)) - transform.position;
            dirGoingBack = dirGoingBack.normalized;
            direction.x = dirGoingBack.x;
            direction.y = dirGoingBack.y;
        }
        transform.position += direction * speed/500;
    }

    IEnumerator ChangeDirections()
    {
        changeDirection = true;
        yield return new WaitForSeconds(1.0f);
        direction.x = Random.Range(-1.0f, 1.0f);
        direction.y = Random.Range(-1.0f, 1.0f);
        changeDirection = false;
    }
    public  void ChangePos(List<Dad> dads)
    {
        for(int i = 0; i < dads.Count; i++)
        {
            if (this != dads[i] && Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(dads[i].transform.position.x, dads[i].transform.position.y)) < 1f)
            {
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(marginSide, Screen.width - marginSide), Random.Range(marginTopBot, Screen.height - marginTopBot), 0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(marginSide, Screen.width - marginSide), Random.Range(marginTopBot, Screen.height - marginTopBot), 0)).y, 0);
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
    public void InitButtons(GameObject button01,GameObject button02)
    {
        button01.transform.SetParent(transform);
        button02.transform.SetParent(transform);
        /*button01.transform.localPosition = new Vector3(0, -DadsScript.dadsManager.marginButton, 0);
        button02.transform.localPosition = new Vector3(0, DadsScript.dadsManager.marginButton, 0);*/
        button01.transform.localPosition = new Vector3(-DadsScript.dadsManager.marginButton, 0, 0);
        button02.transform.localPosition = new Vector3(DadsScript.dadsManager.marginButton, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.name == "InteriorLevel")
        {
            goingBack = false;
            inLevel = true;
            Debug.Log("Heho");
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.name == "InteriorLevel")
        {
            Debug.Log("Heho2");
            inLevel = false;
        }
    }
}
