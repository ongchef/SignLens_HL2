using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unseenObject : MonoBehaviour
{
    public GameObject model;

    public void unseen()
    {
        model.SetActive(false);

    }
}
