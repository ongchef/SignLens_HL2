using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using System.Threading.Tasks;

public class ProgressChange : MonoBehaviour
{
    [SerializeField, Header("Indicators")]
    private GameObject progressIndicatorLoadingBarGo = null;
    [SerializeField]
    private GameObject progressIndicatorRotatingObjectGo = null;
    [SerializeField]
    private GameObject progressIndicatorRotatingOrbsGo = null;

    [SerializeField, Header("Editor Keyboard Controls")]
    private KeyCode toggleBarKey = KeyCode.Alpha1;
    [SerializeField]
    private KeyCode toggleRotatingKey = KeyCode.Alpha2;
    [SerializeField]
    private KeyCode toggleOrbsKey = KeyCode.Alpha3;

    [SerializeField, Header("Settings")]
    private string[] loadingMessages = new string[] {
            "First Loading Message",
            "Loading Message 1",
            "Loading Message 2",
            "Loading Message 3",
            "Final Loading Message" };

    [SerializeField, Range(1f, 10f)]
    private float loadingTime = 5f;

    private IProgressIndicator progressIndicatorLoadingBar;
    private IProgressIndicator progressIndicatorRotatingObject;
    private IProgressIndicator progressIndicatorRotatingOrbs;
    public GameObject pointer1;
    public GameObject pointer2;
    //maybe 3 4?
    bool p1 = false;
    bool p2 = false;
    private float timer = 0;
    private bool direct = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void OnClickBar()
    {
        HandleButtonClick(progressIndicatorLoadingBar);
    }

    /// <summary>
    /// Target method for demo button
    /// </summary>
    public void OnClickRotating()
    {
        HandleButtonClick(progressIndicatorRotatingObject);
    }

    /// <summary>
    /// Target method for demo button
    /// </summary>
    public void OnClickOrbs()
    {
        HandleButtonClick(progressIndicatorRotatingOrbs);
    }

    private async void HandleButtonClick(IProgressIndicator indicator)
    {
        // If the indicator is opening or closing, wait for that to finish before trying to open / close it
        // Otherwise the indicator will display an error and take no action
        await indicator.AwaitTransitionAsync();

        switch (indicator.State)
        {
            case ProgressIndicatorState.Closed:
                OpenProgressIndicator(indicator);
                break;

            case ProgressIndicatorState.Open:
                await indicator.CloseAsync();
                break;
        }
    }

    private void OnEnable()
    {
        progressIndicatorLoadingBar = progressIndicatorLoadingBarGo.GetComponent<IProgressIndicator>();
        progressIndicatorRotatingObject = progressIndicatorRotatingObjectGo.GetComponent<IProgressIndicator>();
        progressIndicatorRotatingOrbs = progressIndicatorRotatingOrbsGo.GetComponent<IProgressIndicator>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer > 5 && direct == true)
        {
            changePointer();
        }
        if (UnityEngine.Input.GetKeyDown(toggleBarKey))
        {
            HandleButtonClick(progressIndicatorLoadingBar);
        }

        if (UnityEngine.Input.GetKeyDown(toggleRotatingKey))
        {
            HandleButtonClick(progressIndicatorRotatingObject);
        }

        if (UnityEngine.Input.GetKeyDown(toggleOrbsKey))
        {
            HandleButtonClick(progressIndicatorRotatingOrbs);
        }

    }
    public void changePointer()
    {
        direct = true;
        timer = 0;
        if (p1 == p2)
        {
            OnClickBar();
            pointer1.SetActive(true);
            p1 = true;
        }
        else
        {
            p1 = !p1;
            p2 = !p2;
            if (p1)
            {
                OnClickBar();
                OnClickBar();
            }
            else
            {
                OnClickBar();
                OnClickBar();
            }
            Debug.Log("p1:" + p1);
            Debug.Log("p2:" + p2);
            pointer1.SetActive(p1);
            pointer2.SetActive(p2);
        }
    }

    private async void OpenProgressIndicator(IProgressIndicator indicator)
    {
        await indicator.OpenAsync();

        float timeStarted = Time.time;
        while (Time.time < timeStarted + loadingTime)
        {
            float normalizedProgress = Mathf.Clamp01((Time.time - timeStarted) / loadingTime);
            indicator.Progress = normalizedProgress;
            indicator.Message = loadingMessages[Mathf.FloorToInt(normalizedProgress * loadingMessages.Length)];

            await Task.Yield();

            switch (indicator.State)
            {
                case ProgressIndicatorState.Open:
                    break;

                default:
                    // The indicator was closed
                    return;
            }
        }

        await indicator.CloseAsync();
    }
}

