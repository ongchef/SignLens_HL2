using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using TMPro;
using System.Linq;

public class Demo : MonoBehaviour
{
    public TextMeshPro TMP;
    string[] wordsArray = new string[] { };
    private bool demoStart = false;
    int count ;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (demoStart) 
        { 
        string text = "";
        foreach (string word in wordsArray)
        {
            text += word;
        }
        Debug.Log(text);
        TMP.SetText(text);
        TMP.ForceMeshUpdate();
        }
    }
    public void Demon() 
    {
        wordsArray = new string[] { };
        demoStart = true;
        Invoke("Concat1", 2f );
        Invoke("Concat1", 4.8f);
        Invoke("Concat1", 5.8f);
        Invoke("Concat1", 7.8f);
        Invoke("Concat1", 10f);
        Invoke("Concat1", 11.6f);
        Invoke("Concat1", 13f);
    }
    public void Concat1() 
    {
        if (count == 0) 
        {
            wordsArray = wordsArray.Concat(new string[] { "我" }).ToArray();
            
        }
        if (count == 1)
        {
            wordsArray = wordsArray.Concat(new string[] { "要" }).ToArray();
            
        }
        if (count == 2)
        {
            wordsArray = wordsArray.Concat(new string[] { "幫" }).ToArray();
            
        }
        if (count == 3)
        {
            wordsArray = wordsArray.Concat(new string[] { "小孩" }).ToArray();
            
        }
        if (count == 4)
        {
            wordsArray = wordsArray.Concat(new string[] { "開" }).ToArray();
            
        }
        if (count == 5)
        {
            wordsArray = wordsArray.Concat(new string[] { "銀行" }).ToArray();
           
        }
        if (count == 6)
        {
            wordsArray = wordsArray.Concat(new string[] { "帳戶" }).ToArray();
   
        }
        count += 1;
    }
    public void ClearList()
    {
        TMP.SetText("");
        wordsArray = new string[] { };
    }
}
