using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameRules : MonoBehaviour {

    //the difficutly of the level
    public int levelDifficulty = 1;
    //the loseing a life sound
    public AudioSource loseLife;
    //the points sound
    public AudioSource pointSound;
    //next level to go to
    public string nextLevel;

    //UI of score
    private Text _scoreText;
    //points values
    private int _addPoints = 100;
    private int _totalPoints = 0;
    //cubes to hit
    private int _cubesLeft;

    //ui of lives
    private Text _livesText;
    private int _curLives;

    //key to get from player pref
    string _key = "CUR_SCORE";

    // Use this for initialization
    void Start () {
        //set number of cubes to touch
        _cubesLeft = 28 * levelDifficulty;
        //set text ui components
        _scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        //if points exist use them
        if (PlayerPrefs.HasKey(_key))
        {
            _totalPoints = PlayerPrefs.GetInt(_key);
            _scoreText.text = _totalPoints.ToString();
        }
        //get the total number of lives
        _livesText = GameObject.Find("livesText").GetComponent<Text>();
    }

    public void SubtractLife()
    {
        //this constantly says its destroyed but its not?
        loseLife.Play();
        //parse current lives
        _curLives = int.Parse(_livesText.text);
        //subtract a life
        --_curLives;
        if (_curLives == 0)
        {
            //game over
            Gameover();
        }
        else
        {
            //set the string
            _livesText.text = _curLives.ToString();
        }
    }

    public void AddPoints()
    {
        pointSound.Play();
        //parse current points
        _totalPoints = int.Parse(_scoreText.text);
        //add the new points on
        _totalPoints += _addPoints;
        //set the string
        _scoreText.text = _totalPoints.ToString("0000000000");
        //subtract from cubes left
        --_cubesLeft;
        if(_cubesLeft == 0)
        {
            //go to next level
            IncreaseLevel();
        }
    }

    public void IncreaseLevel()
    {
        //set score score
        PlayerPrefs.SetInt(_key, _totalPoints);
        //load next level
        SceneManager.LoadScene(nextLevel);
    }



    void Gameover()
    {
        //set score score
        PlayerPrefs.SetInt(_key, _totalPoints);
        //load game over
        SceneManager.LoadScene("GameOver");
    }
}
