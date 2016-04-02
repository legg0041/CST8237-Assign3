using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

    //UI of score
    private Text _scoreText;
    //key to get from player pref
    string _key = "CUR_SCORE";

    // Use this for initialization
    void Start () {
        //set text ui components
        _scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        if (PlayerPrefs.HasKey(_key))
        {
            _scoreText.text = PlayerPrefs.GetInt(_key).ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
