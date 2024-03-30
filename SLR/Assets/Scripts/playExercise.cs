using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playExercise : MonoBehaviour
{
    public float sec;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.PlayDelayed(sec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
