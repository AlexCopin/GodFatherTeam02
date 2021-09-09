using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class DadsScript : MonoBehaviour
{
    public static DadsScript dadsManager;
    public float marginSides;
    public float marginTop;
    public Transform[] dadsBunnies;
    public List<Dad> dads;
	//public List<Button> Buttons;
	public Timer timer;
    public int playerWin = 0;

    private bool fail1 = false;
    private bool fail2 = false;
    private int index1 = -1;
    private int index2 = -1;

    private void Awake()
    {
        if (dadsManager == null)
        {
            dadsManager = this;
        }
        else if (dadsManager != this)
            Destroy(gameObject);
    }
    void Start()
    {
        InitDads();
        //InitButtons();
        timer.RebootTimer();
        timer.ActiveTimer();
    }

    void Update()
    {
        if(fail1 && fail2)
        {
            timer.EndLevel();
        }

        //Player 1
        if (!fail1)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                index1 = 0;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                index1 = 1;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                index1 = 2;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                index1 = 3;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                index1 = 4;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                index1 = 5;
            }

            if (index1 == 5 && DadsScript.dadsManager.dads.Count == 6
                ||index1 == 4 && DadsScript.dadsManager.dads.Count >= 5
                ||index1 == 3 && DadsScript.dadsManager.dads.Count >= 4 
                || (index1 < 3 && index1 >-1))
            {

                Debug.Log("Index 1 est " + index1);
                if (DadsScript.dadsManager.dads[index1].realDad)
                {
                    Debug.Log("P1 win");
                    playerWin = 1;
                    timer.EndLevel();
                }
                else
                {
                    Debug.Log("P1 fail");
                    fail1 = true;
                }
            }
        }



        //Player 2
        if (!fail2)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                index2 = 0;
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                index2 = 1;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                index2 = 2;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                index2 = 3;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                index2 = 4;
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                index2 = 5;
            }

            if (index2 == 5 && DadsScript.dadsManager.dads.Count == 6
                || index2 == 4 && DadsScript.dadsManager.dads.Count >= 5
                || index2 == 3 && DadsScript.dadsManager.dads.Count >= 4
                || (index2 < 3 && index2 > -1))
            {

                Debug.Log("Index 2 est " + index2);
                if (DadsScript.dadsManager.dads[index2].realDad)
                {
                    Debug.Log("P2 win");
                    playerWin = 2;
                    timer.EndLevel();
                }
                else
                {
                    Debug.Log("P2 win");
                    fail2 = true;
                }
            }
        }
    }

    void InitDads()
    {
        //int rand;
        playerWin = 0;
        index1 = -1;
        index2 = -1;
        foreach (Dad d in dads)
        {
            /*rand = Random.Range(0, dadsBunnies.Length);
            while (dads.Find(x => x.index == rand))
            {
                rand = Random.Range(0, dadsBunnies.Length);
            }
            d.index = rand;*/
            d.ChangePos(dads);
            //d.ChangePos(dadsBunnies[d.index]);
        }
        /*List<Dad> SortedList = dads.OrderBy(o => o.index).ToList();
        dads = SortedList;*/
    }
    /*void InitButtons()
    {
        for (int i = 0; i <= dads.Count - 1; i++)
        {
            Buttons.Add(dads[i].gameObject.GetComponent<Button>());
            int x = i;
            Buttons[i].onClick.AddListener(() => { DadOnClick(x); });
        }
    }*/

	void DadOnClick(int index)
	{
		if (DadsScript.dadsManager.dads[index].realDad)
		{
			timer.EndLevel();
		}
		else
		{
			timer.MinusTimer();
		}
	}


}
