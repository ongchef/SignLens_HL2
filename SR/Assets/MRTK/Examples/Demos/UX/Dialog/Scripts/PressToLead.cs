using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToLead : MonoBehaviour
{
    bool leading = false;
    public GameObject Target1;
    public GameObject Target2;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lead()
    {
        if (leading == false)
        {
            Target1.SetActive(true);
            Target2.SetActive(true);
            leading = true;
        }
        else if (leading == true)
        {
            Target1.SetActive(false);
            Target2.SetActive(false);
            leading = false;
        }
    }
}
