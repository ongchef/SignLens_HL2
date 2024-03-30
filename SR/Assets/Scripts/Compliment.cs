using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compliment : MonoBehaviour
{
    public GameObject perfectObject;
    public GameObject oneMistakeObject;
    public GameObject mistakesObject;

    public void Start()
    {
        perfectObject.SetActive(false);
        oneMistakeObject.SetActive(false);
        mistakesObject.SetActive(false);
}

    public void showResultPic(int mistakesAmount)
    {
        if (mistakesAmount==0)
        {
            perfectObject.SetActive(true);
        }

        else if (mistakesAmount <= 1)
        {
            oneMistakeObject.SetActive(true);
        }

        else 
        {
            mistakesObject.SetActive(true);
        }
    }

}
