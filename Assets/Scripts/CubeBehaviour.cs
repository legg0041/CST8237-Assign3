using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CubeBehaviour : MonoBehaviour {

    //materials to change to upon touch
    public Material noTouch;
    public Material firstTouch;
    public Material secondTouch;
    public Material thirdTouch;
    public Material fourthTouch;
    //renderer of the cube
    public Renderer boxRenderer;
    //the players parent
    public GameObject playerParent;

    //number of times collided
    private int _numTouches = 0;
    private int _maxTouches;
    private GameRules _gameRules;
    // Use this for initialization
    void Start () {
        var gameController = GameObject.FindGameObjectWithTag("Rules");
        _gameRules = gameController.GetComponent<GameRules>();
        _maxTouches = _gameRules.levelDifficulty;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        // if its the player
        if (coll.collider.name.StartsWith("Player"))
        {
            //and it hasnt reached the max touches
            if(_numTouches < _maxTouches)
            {
                //add points
                _gameRules.AddPoints();
                //increase touch count
                ++_numTouches;
                //check which color to go to
                switch (_numTouches)
                {
                    case 1:
                        boxRenderer.material.color = firstTouch.color;
                        break;
                    case 2:
                        boxRenderer.material.color = secondTouch.color;
                        break;
                    case 3:
                        boxRenderer.material.color = thirdTouch.color;
                        break;
                    case 4:
                        boxRenderer.material.color = fourthTouch.color;
                        break;
                }
            }
        }
    }
}
