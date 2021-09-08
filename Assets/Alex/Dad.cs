using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dad : MonoBehaviour
{
    
    public bool real;
    public Color color;
    public int index;
    public Sprite body;


    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = body;
        GetComponent<SpriteRenderer>().color = color;
    }

    public void ChangePos(Transform newPos)
    {
        transform.position = newPos.position;
    }
}
