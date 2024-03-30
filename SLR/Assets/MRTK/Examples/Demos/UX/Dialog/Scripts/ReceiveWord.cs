using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using System.Linq;
using UnityEngine;
using System.Threading;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

public class ReceiveWord : MonoBehaviour
{
    private int port=7000;
    private string ip= "192.168.0.155";
    public TextMeshPro TMP;
    Socket socket = null;
    int gc_count = 0;
    string rectext="";
    //public GameObject background;
    //public SpriteRenderer backgroundSpriteRenderer;
    private System.Object threadLocker = new System.Object();
    bool success = true;
    bool send = false;
    Queue<string> words = new Queue<string>();
    string[] wordsArray = new string[]{ };
    string[] dic = new string[]{"我", "要", "幫", "小孩", "開", "銀行", "帳戶", "儲蓄", "有"};
    private MixedRealityKeyboard wmrKeyboard;
    [SerializeField]
    private TextMeshPro debugMessage = null;
    [SerializeField]
    private MixedRealityKeyboardPreview mixedRealityKeyboardPreview = null;
    private bool disableUIInteractionWhenTyping = false;

    // Start is called before the first frame update
    void Start()
    {
        //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //socket.Connect(IPAddress.Parse(ip), port);
        if (mixedRealityKeyboardPreview != null)
        {
            mixedRealityKeyboardPreview.gameObject.SetActive(false);
        }



        // Windows mixed reality keyboard initialization goes here
        wmrKeyboard = gameObject.AddComponent<MixedRealityKeyboard>();
        wmrKeyboard.DisableUIInteractionWhenTyping =
                disableUIInteractionWhenTyping;

    }
    public void ConnectServer() 
    {
        //ip = wmrKeyboard.Text;
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(IPAddress.Parse(ip), port);
        debugMessage.SetText("ip "+ip+"connect");
    }

    // Update is called once per frame
    void Update()
    {
        lock (threadLocker)
        {
            if (send)
            {
                if (success)
                {
                    success = false;
                    //Debug.Log("Rec");
                    SendTexture();
                    //Vector2 textSize = TMP.GetRenderedValues(false);
                    //Vector2 padding = new Vector2(0.2f, 0.2f);
                    //backgroundSpriteRenderer.size = textSize + padding;
                }
                /*
                if (isNewAdd > 0)
                {
                    isNewAdd = 0;
                    SendTexture(1);
                }
                */
            }
        }
    }
    void SendTexture()
    {
        byte[] byterec = new byte[1024];
        int br = socket.Receive(byterec);
        rectext = Encoding.UTF8.GetString(byterec, 0, br);
        Debug.Log(rectext);

        if (wordsArray.Length != 0 || rectext == "我")
        {
            if (dic.Contains(rectext))
            {
                if (wordsArray.Any(rectext.Contains))
                {
                    wordsArray = wordsArray.Where(val => val != rectext).ToArray();
                    wordsArray = wordsArray.Concat(new string[] { rectext }).ToArray();
                }
                else
                {
                    wordsArray = wordsArray.Concat(new string[] { rectext }).ToArray();
                }
            }
        }

        //if (rectext == "我") 
        //{
        //    if (wordsArray.Any(rectext.Contains))
        //    {
        //        wordsArray = wordsArray.Where(val => val != rectext).ToArray();
        //        wordsArray = wordsArray.Concat(new string[] { rectext }).ToArray();

        //    }
        //    else
        //    {
        //        wordsArray = wordsArray.Concat(new string[] { rectext }).ToArray();
        //    }

        //}
        //else 
        //{
        //    if (wordsArray.Length == 0)
        //    {
        //    }
        //    else 
        //    {
        //        if (wordsArray.Any(rectext.Contains))
        //        {
        //            wordsArray = wordsArray.Where(val => val != rectext).ToArray();
        //            wordsArray = wordsArray.Concat(new string[] { rectext }).ToArray();

        //        }
        //        else
        //        {
        //            wordsArray = wordsArray.Concat(new string[] { rectext }).ToArray();
        //        }
        //    }
        //}
        //if (rectext == "i")
        //{
        //    if (words.Contains(rectext))
        //    {
        //        //words.Enqueue(rectext);
        //    }
        //    else if (words.Count > 7)
        //    {
        //        words.Dequeue();
        //        words.Enqueue(rectext);
        //    }
        //    else
        //    {
        //        words.Enqueue(rectext);
        //    }
        //}
        //else 
        //{
        //    if (words.Count == 0)
        //    {
        //    }
        //    else 
        //    {
        //        if (words.Contains(rectext))
        //        {
        //            //words.Enqueue(rectext);
        //        }
        //        else if (words.Count > 7)
        //        {
        //            words.Dequeue();
        //            words.Enqueue(rectext);
        //        }
        //        else
        //        {
        //            words.Enqueue(rectext);
        //        }
        //    }

        //}
        string text = "";
        foreach (string word in wordsArray)
        {
            text += word;
        }
        TMP.SetText(text);
        //TMP.SetText(rectext);
        TMP.ForceMeshUpdate();
        
        //TMP.text = text;
        gc_count++;
        if (gc_count > 5000)
        {
            gc_count = 0;
            GC.Collect(2);
        }
        //Debug.Log("" + (float)bytes.Length / 1024f + "KB");
        success = true;
    }
    public void SendStart()
    {
        //background.SetActive(true);
        send = !send;
        socket.Send(Encoding.UTF8.GetBytes("START"));
    }
    public void ClearList()
    {
        TMP.SetText("");
        words.Clear();
        wordsArray = new string[] { };
    }
    public void Demo()
    {
        Thread.Sleep(1000);
        wordsArray = wordsArray.Concat(new string[] { "我" }).ToArray();
        Thread.Sleep(1000);
        wordsArray = wordsArray.Concat(new string[] { "要" }).ToArray();
        Thread.Sleep(1500);
        wordsArray = wordsArray.Concat(new string[] { "幫" }).ToArray();
        Thread.Sleep(1250);

    }
}
