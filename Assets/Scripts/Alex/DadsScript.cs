using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class DadsScript : MonoBehaviour
{
    public static DadsScript dadsManager;
    public Transform[] dadsBunnies;
    public List<Dad> dads;
	[SerializeField] List<Button> Buttons;

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
        int rand;
        foreach (Dad d in dads)
        {
            rand = Random.Range(0, dadsBunnies.Length);
            while (dads.Find(x => x.index == rand))
            {
                rand = Random.Range(0, dadsBunnies.Length);
            }
            d.index = rand;
            d.ChangePos(dadsBunnies[d.index]);

		}
		List<Dad> SortedList = dads.OrderBy(o => o.index).ToList();
        dads = SortedList;
		foreach(Dad d in dads)
        {
			Buttons.Add(d.gameObject.GetComponent<Button>());
		}
		InitButtons();

	}


	void InitButtons()
	{
		Button btn = Buttons[0].GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClickForFirstButton);

		Button btn2 = Buttons[1].GetComponent<Button>();
		btn2.onClick.AddListener(TaskOnClickForSecondButton);

		Button btn3 = Buttons[2].GetComponent<Button>();
		btn3.onClick.AddListener(TaskOnClickForThirdButton);

	}

	void TaskOnClickForFirstButton()
	{
		if (DadsScript.dadsManager.dads[0].realDad)
		{
			Debug.Log(DadsScript.dadsManager.dads[0].name + "Win!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else
		{
			Debug.Log(DadsScript.dadsManager.dads[0].name + "Lose!");
		}
	}

	void TaskOnClickForSecondButton()
	{
		if (DadsScript.dadsManager.dads[1].realDad)
		{
			Debug.Log(DadsScript.dadsManager.dads[1].name + "Win!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else
		{
			Debug.Log(DadsScript.dadsManager.dads[1].name + "Lose!");
		}
	}

	void TaskOnClickForThirdButton()
	{
		if (DadsScript.dadsManager.dads[2].realDad)
		{
			Debug.Log(DadsScript.dadsManager.dads[2].name + "Win!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else
		{
			Debug.Log(DadsScript.dadsManager.dads[2].name + "Lose!");
		}
	}
}
