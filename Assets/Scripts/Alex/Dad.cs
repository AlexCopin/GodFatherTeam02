using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dad : MonoBehaviour
{
    [Header("Movement")]
    public Vector2 speedRange;
    public float speed;
    float zPos;
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
        zPos = transform.position.z;
        speed = Random.Range(speedRange.x, speedRange.y);
        marginSide = DadsScript.dadsManager.marginSides * Screen.width;
        marginTopBot = DadsScript.dadsManager.marginTop * Screen.height;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(marginSide, Screen.width- marginSide), Random.Range(marginTopBot, Screen.height- marginTopBot),0));
    }

    void Update()
    {
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
            direction.z = zPos;
        }
        direction.z = zPos;
        transform.position = new Vector3(transform.position.x + direction.x * speed / 500, transform.position.y + direction.y * speed / 500, 0);
    }

    IEnumerator ChangeDirections()
    {
        changeDirection = true;
        yield return new WaitForSeconds(1.0f);
        direction.x = Random.Range(-1.0f, 1.0f);
        direction.y = Random.Range(-1.0f, 1.0f);
        changeDirection = false;
    }
    public  void ChangePos()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(marginSide, Screen.width - marginSide), Random.Range(marginTopBot, Screen.height - marginTopBot), 0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(marginSide, Screen.width - marginSide), Random.Range(marginTopBot, Screen.height - marginTopBot), 0)).y, zPos);
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
    }
    public void InitButtons(GameObject button01,GameObject button02)
    {
        button01.transform.SetParent(transform);
        button02.transform.SetParent(transform);
        button01.transform.localPosition = new Vector3(DadsScript.dadsManager.marginButton, 0, zPos);
        button02.transform.localPosition = new Vector3(-DadsScript.dadsManager.marginButton, 0, zPos);
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.name == "InteriorLevel")
        {
            goingBack = false;
            inLevel = true;
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.name == "InteriorLevel")
        {
            inLevel = false;
        }
    }
}
