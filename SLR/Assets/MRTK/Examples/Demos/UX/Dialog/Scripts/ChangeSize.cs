using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Globalization;
using System;
using System.Diagnostics;
using TMPro;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
using Debug = UnityEngine.Debug;

public class ChangeSize : MonoBehaviour
{
    public GameObject background;
    public SpriteRenderer backgroundSpriteRenderer;
    private System.Object threadLocker = new System.Object();
    public TextMeshPro Text;

    // Start is called before the first frame update
    void Start()
    {
        background.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        lock (threadLocker)
        {
            Vector2 textSize = Text.GetRenderedValues(false);
            Vector2 padding = new Vector2(0.2f, 0.2f);
            backgroundSpriteRenderer.size = textSize + padding;
        }
    }
}
