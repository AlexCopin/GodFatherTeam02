using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorCs : MonoBehaviour
{
    float speed = 5f;
    public GameObject curs;
    // Start is called before the first frame update
    void Start()
    {
        curs = GameObject.Find("CursorPivot");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursPos = Input.mousePosition;
        Vector3 cursWPos = Camera.main.ScreenToWorldPoint(cursPos);
        curs.transform.position = new Vector3(cursWPos.x, cursWPos.y , curs.transform.position.z);
    }
}
