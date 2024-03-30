using System.Net.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Text;
using TMPro;
using System.Linq;
using System.Threading;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

public class ConnectServer : MonoBehaviour
{
    public string host = "192.168.0.178";
    public int port = 12345;
    TcpClient client = new TcpClient();
    // Start is called before the first frame update
    void Start()
    {
        //Console.WriteLine("Connecting");
        Debug.Log("Connecting");
        // Connect to the server
        client.Connect("192.168.0.178", 12345);
        //Console.WriteLine("Connected");
        Debug.Log("Connecteds");

    }

    // Update is called once per frame
    void Update()
    {
        byte[] buffer = new byte[144];
        int bytesRead = client.GetStream().Read(buffer, 0, buffer.Length);
        byte[] receivedData = new byte[bytesRead];
        Array.Copy(buffer, receivedData, bytesRead);

        // Convert the received data back to an array
        float[] arrayData = new float[receivedData.Length / sizeof(float)];
        Buffer.BlockCopy(receivedData, 0, arrayData, 0, bytesRead);

        // Display the received array data
        Debug.Log("Received Array:"+ arrayData[0]);
        //Debug.Log();
        //foreach (float value in arrayData)
        //{
        //    Debug.Log(value);
        //}
    }
}
