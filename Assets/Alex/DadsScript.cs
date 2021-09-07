using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadsScript : MonoBehaviour
{
    public Transform[] dadsBunnies;
    public List<Dad> dads;
    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
