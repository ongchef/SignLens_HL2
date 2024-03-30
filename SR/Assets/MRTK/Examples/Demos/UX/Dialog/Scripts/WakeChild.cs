using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeChild : MonoBehaviour
{
    public GameObject parentAnchor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WakeUpchildren() 
    {
        Debug.Log(parentAnchor.transform.childCount);
        for (int a = 0; a < parentAnchor.transform.childCount; a++)
        {
            parentAnchor.transform.GetChild(a).gameObject.SetActive(true);
            Debug.Log(a+1);
        }
        //Debug.Log("Waked");
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        parentAnchor.transform.SetPositionAndRotation(parentAnchor.transform.position,rotation);
    }
}
