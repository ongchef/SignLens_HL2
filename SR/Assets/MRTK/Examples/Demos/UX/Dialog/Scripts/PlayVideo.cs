using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    public GameObject Target;
    VideoPlayer pV = new VideoPlayer();

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play() 
    {
        Target.SetActive(true);
        pV = Target.GetComponent<VideoPlayer>();
        pV.Play();
    }
}
