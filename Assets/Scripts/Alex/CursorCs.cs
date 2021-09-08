using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorCs : MonoBehaviour
{
    public float speed;
    Vector3 cursPos;
    public GameObject curs;
    // Start is called before the first frame update
    void Start()
    {
        curs = GameObject.Find("CursorPivot");
    }

    // Update is called once per frame
    void Update()
    {
        cursPos = Input.mousePosition;
        cursPos = Camera.main.ScreenToWorldPoint(cursPos);
        curs.transform.position = Vector3.Lerp(curs.transform.position, new Vector3(cursPos.x, cursPos.y, curs.transform.position.z) , speed);
    }
}
