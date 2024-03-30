using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class countAndCheck : MonoBehaviour
{
    public GameObject target;
    public int answer;
    public itemList itemlist;
    public int sceneIndex;
    public TextMeshPro t;
    public int sceneScore;//current scene score
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        itemlist.increase();
        t.text = itemlist.getCount().ToString();
    }
    void OnTriggerExit(Collider other)
    {
        itemlist.decrease();
        t.text = itemlist.getCount().ToString();
    }

    public void check()
    {
        if (answer == itemlist.getCount())
        {
            testResult.result.Add(1);
            //把每一關的分數存下來
            testResult.scores.Add(sceneScore+1);
            //跳下一個難度
            SceneManager.LoadScene(sceneIndex+4);
        }
        else
        {
            testResult.result.Add(0);
            //把每一關的分數存下來
            testResult.scores.Add(sceneScore);
            //維持難度
            SceneManager.LoadScene(sceneIndex+3);
        }
        //SceneManager.LoadScene(sceneIndex);

    }
}
