using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dad : MonoBehaviour
{
    
    public bool realDad;
    public Color color;
    public int index;
    public Sprite body;


    private void Start()
    {
        GetComponentInChildren<Image>().sprite = body;
        GetComponentInChildren<Image>().color = color;
    }

    public void ChangePos(Transform newPos)
    {
        transform.position = new Vector3(newPos.position.x, newPos.position.y, 0);
    }
}
