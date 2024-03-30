using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class detectAndCheckAnswer : MonoBehaviour
{
    public GameObject target;
    public TextMeshPro t1;
    public string answer;
    public itemList itemlist ;
    public int sceneIndex;//current scene index
    public int sceneScore;//current scene score
    private List<string> inbasket = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        //testResult.scores.Add(sceneScore);
    }

    // Update is called once per frame
    void Update()
    {
        inbasket = itemlist.getList();
    }
  
    void OnTriggerEnter(Collider other)
    {
       itemlist.additem(target.name);
       t1.text = "now: " + string.Join(" ", inbasket);
    }
    void OnTriggerExit(Collider other) 
    {
        itemlist.removeitem(target.name);
        t1.text = "now: " + string.Join(" ", inbasket);
    }
   
    public void check()
    {
        if (inbasket.Count == 1 && inbasket.Contains(answer))
        {
            testResult.result.Add(1);
            Debug.Log("correct");
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
    public void checkC1()
    {

        //設C1題目為2藍筆+1黑筆 // && inbasket.Contains("greenFan")&& inbasket.Contains("blueFan")
        //Debug.Log(string.Join(" ", inbasket));
        //第三題結束直接進總結頁面
        if (inbasket.Count == 3 && (inbasket.Contains("blackP (1)") || inbasket.Contains("blackP (2)") || inbasket.Contains("blackP"))&&((inbasket.Contains("blueP (1)") && inbasket.Contains("blueP (2)")) || (inbasket.Contains("blueP (1)") && inbasket.Contains("blueP")) || (inbasket.Contains("blueP (2)") && inbasket.Contains("blueP"))))//((inbasket.Contains("gf")&& inbasket.Contains("gf")) || (inbasket.Contains("gf") && (inbasket.Contains("gf"))|| (inbasket.Contains("gf") && (inbasket.Contains("gf")) && (inbasket.Contains("blackP (1)") || inbasket.Contains("blackP (2)") || inbasket.Contains("blackP")))
        {
            testResult.result.Add(1);
            //把每一關的分數存下來
            testResult.scores.Add(sceneScore+1);
            //答對繼續下一關
            SceneManager.LoadScene(9);
        }
        else
        {
            testResult.result.Add(0);
            Debug.Log(string.Join(" ", inbasket));
            //把每一關的分數存下來
            testResult.scores.Add(sceneScore);
            //答錯繼續下一關
            SceneManager.LoadScene(9);
        }
        //SceneManager.LoadScene(sceneIndex);
    }

    public void checkC2()
    {

        //設C2題目為所有綠色物品 // && inbasket.Contains("greenFan")&& inbasket.Contains("blueFan")
        //Debug.Log(string.Join(" ", inbasket));
        //第三題結束直接進總結頁面
        if (inbasket.Contains("greenSlippers") || inbasket.Contains("greenBasketball") || inbasket.Contains("gf"))
        {
            testResult.result.Add(1);
            //把每一關的分數存下來
            testResult.scores.Add(sceneScore + 1);
            //答對繼續下一關
            SceneManager.LoadScene(9);
        }
        else
        {
            testResult.result.Add(0);
            Debug.Log(string.Join(" ", inbasket));
            //把每一關的分數存下來
            testResult.scores.Add(sceneScore);
            //答錯繼續下一關
            SceneManager.LoadScene(9);
        }
        //SceneManager.LoadScene(sceneIndex);
    }

    public void checkC3()
    {

        //設C3題目為1綠色拖鞋+1藍色拖鞋+1黑筆 // && inbasket.Contains("greenFan")&& inbasket.Contains("blueFan")
        //Debug.Log(string.Join(" ", inbasket));
        //第三題結束直接進總結頁面
        if ((inbasket.Contains("greenSlippers (1)") || inbasket.Contains("greenSlippers"))&&(inbasket.Contains("BlueSlippers (1)") || inbasket.Contains("BlueSlippers"))&& inbasket.Contains("blackPen"))
        {
            testResult.result.Add(1);
            //把每一關的分數存下來
            testResult.scores.Add(sceneScore + 1);
            //答對繼續下一關
            SceneManager.LoadScene(9);
        }
        else
        {
            testResult.result.Add(0);
            Debug.Log(string.Join(" ", inbasket));
            //把每一關的分數存下來
            testResult.scores.Add(sceneScore);
            //答錯繼續下一關
            SceneManager.LoadScene(9);
        }
        //SceneManager.LoadScene(sceneIndex);
    }
}