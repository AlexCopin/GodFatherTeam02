using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArrowController : MonoBehaviour
{
    private int state = 1;
    [SerializeField] GameObject[] Arrows;
    // Start is called before the first frame update
    void Start()
    {
        Arrows[1].GetComponent<Image>().color = Color.red;
    }

    // Update is called once per frame
    void Update()                                  //systeme pour choisir le père
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (state != 0)
            {
                Arrows[0].GetComponent<Image>().color = Color.white;
                Arrows[1].GetComponent<Image>().color = Color.white;
                Arrows[2].GetComponent<Image>().color = Color.white;
            }

            if (state == 1)
            {
                Arrows[0].GetComponent<Image>().color = Color.red;
                state = 0;
            }

            if (state == 2)
            {
                Arrows[1].GetComponent<Image>().color = Color.red;
                state = 1;
            }
        }else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (state != 2)
            {
                Arrows[0].GetComponent<Image>().color = Color.white;
                Arrows[1].GetComponent<Image>().color = Color.white;
                Arrows[2].GetComponent<Image>().color = Color.white;
            }

            if (state == 1)
            {
                Arrows[2].GetComponent<Image>().color = Color.red;
                state = 2;
            }

            if (state == 0)
            {
                Arrows[1].GetComponent<Image>().color = Color.red;
                state = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (DadsScript.dadsManager.dads[state].realDad)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("Vous avez gagné");

            }
            else
            {
                Debug.Log("Vous avez perdu");
            }
        }
    }

}
