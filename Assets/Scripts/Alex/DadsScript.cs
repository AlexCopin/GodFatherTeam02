using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DadsScript : MonoBehaviour
{
    public static DadsScript dadsManager;
    public Transform[] dadsBunnies;
    public List<Dad> dads;

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
    }


    void Update()
    {
        
    }
}
