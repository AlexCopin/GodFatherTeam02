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
	public List<Button> Buttons;

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
		for(int i = 0; i <= dads.Count - 1; i++)
		{
			Buttons.Add(dads[i].gameObject.GetComponent<Button>());
			int x = i;
			Buttons[i].onClick.AddListener(() => { DadOnClick(x); });
		}
	}


	void DadOnClick(int index)
	{
		if (DadsScript.dadsManager.dads[index].realDad)
		{
			Debug.Log(DadsScript.dadsManager.dads[index].name + "Win!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else
		{
			Debug.Log(DadsScript.dadsManager.dads[index].name + "Lose!");
		}
	}
}
