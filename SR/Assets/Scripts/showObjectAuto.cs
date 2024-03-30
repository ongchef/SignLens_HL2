using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showObjectAuto : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject item;
    void Start()
    {
        StartCoroutine(wait(10));
    }
    IEnumerator wait(int n)
    {
        yield return new WaitForSeconds(n);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
