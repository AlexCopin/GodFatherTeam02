using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    private int state = 1;
    [SerializeField] GameObject[] Arrows;
    // Start is called before the first frame update
    void Start()
    {
        Arrows[1].GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update()                                  //systeme pour choisir le père
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (state != 0)
            {
                Arrows[0].GetComponent<SpriteRenderer>().color = Color.white;
                Arrows[1].GetComponent<SpriteRenderer>().color = Color.white;
                Arrows[2].GetComponent<SpriteRenderer>().color = Color.white;
            }

            if (state == 1)
            {
                Arrows[0].GetComponent<SpriteRenderer>().color = Color.red;
                state = 0;
            }

            if (state == 2)
            {
                Arrows[1].GetComponent<SpriteRenderer>().color = Color.red;
                state = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (state != 2)
            {
                Arrows[0].GetComponent<SpriteRenderer>().color = Color.white;
                Arrows[1].GetComponent<SpriteRenderer>().color = Color.white;
                Arrows[2].GetComponent<SpriteRenderer>().color = Color.white;
            }

            if (state == 1)
            {
                Arrows[2].GetComponent<SpriteRenderer>().color = Color.red;
                state = 2;
            }

            if (state == 0)
            {
                Arrows[1].GetComponent<SpriteRenderer>().color = Color.red;
                state = 1;
            }
        }
    }

    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.KeypadEnter))
       // {
            //if (state == fatherState)         si la fleche est sur le bon père
            //{
               // Debug.Log("Vous avez gagné");
            //}
            else
            {
                Debug.Log("Vous avez perdu");
            }
    }
}
