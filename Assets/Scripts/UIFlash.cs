using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


/// <summary>
/// Flashes the ui text set
/// </summary>
public class UIFlash : MonoBehaviour {

    //the text component to blink
    public Text textToBlink;
    //blink speed
    public float blinkSpeed = 0.5f;
    //which scene to load
    public string loadScene;
    //key to get from player pref
    string _key = "CUR_SCORE";

    // Use this for initialization
    void Start()
    {
        //repeat call to BlinkText every 0.5s
        InvokeRepeating("BlinkText", blinkSpeed, blinkSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //delete score key
            PlayerPrefs.DeleteKey(_key);
            //load scene
            SceneManager.LoadScene(loadScene);
        }
    }

    /// <summary>
    /// Enables or disables the text
    /// </summary>
    void BlinkText()
    {
        //check if text is enabled
        if (textToBlink.enabled)
        {
            textToBlink.enabled = false;
        }
        else
        {
            textToBlink.enabled = true;
        }
    }
}
