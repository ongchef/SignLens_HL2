using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirect : MonoBehaviour
{
    public GameObject pointer1;
    public GameObject pointer2;
    //maybe 3 4?
    bool p1 = false;
    bool p2 = false;
    private float timer = 0;
    private bool direct = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        timer += Time.deltaTime;
        if (timer > 5 && direct == true)
        {
            changePointer();
        }
    }
    public void changePointer() 
    {
        direct = true;
        timer = 0;
        if (p1 == p2)
        {
            pointer1.SetActive(true);
            p1 = true;
        }
        else
        {
            p1 = !p1;
            p2 = !p2;
            Debug.Log("p1:"+p1);
            Debug.Log("p2:"+p2);
            pointer1.SetActive(p1);
            pointer2.SetActive(p2);
        }
    }
    public void ResetTimer()
    {
        
    }
}
