using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
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
    public void ChangePositionTest() 
    {
        Vector3 position1 = Target1.transform.position;
        Vector3 position2 = Target2.transform.position;
        Debug.Log("" + position1.x + position1.y + position1.z);
        Debug.Log("" + position2.x + position2.y + position2.z);
        position2 = new Vector3(position1.x, position1.y, position1.z +3f);
        Target2.transform.position = position2;
        Debug.Log("New" + position2.x + position2.y + position2.z);

    }
}
