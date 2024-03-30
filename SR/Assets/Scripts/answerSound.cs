using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class answerSound : MonoBehaviour
{
    public AudioSource correct;
    public AudioSource wrong;
    // Start is called before the first frame update
    void Start()
    {
        if(testResult.result.Last() == 1)
        {
            correct.PlayDelayed(1);
        }
        else if (testResult.result.Last() == 0)
        {
            wrong.PlayDelayed(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
