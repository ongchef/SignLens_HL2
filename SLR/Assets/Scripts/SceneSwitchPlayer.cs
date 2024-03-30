using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchPlayer : MonoBehaviour
{
    public int sceneIndex;
    public string sceneName;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
            Console.WriteLine("Triggered");
        }
    }
}
