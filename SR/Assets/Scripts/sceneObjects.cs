using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneObjects : MonoBehaviour
{
    public GameObject model;
    public int sec = 10;
    // Start is called before the first frame update
    void Start()
    {
        //model.SetActive(false);
        transform.position = transform.position + new Vector3(0, 0, 100);
        model.GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(waitforsec(sec));
    }
    
    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    IEnumerator waitforsec(int s)
    {
        yield return new WaitForSeconds(s);
        transform.position = transform.position + new Vector3(0, 0, -100);
        model.GetComponent<Rigidbody>().isKinematic = false;
        
    }
    public void showModel()
    {
        model.SetActive(true);
    }
}