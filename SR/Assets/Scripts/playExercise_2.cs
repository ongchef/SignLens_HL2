using UnityEngine;

public class playExercise_2 : MonoBehaviour
{
    //public float sec;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        //float sec = 6;
        audioData = GetComponent<AudioSource>();
        audioData.PlayDelayed(6);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
