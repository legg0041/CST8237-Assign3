using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    //the empty parent object
    public GameObject myParent;
    //the jump sound to play
    public AudioSource jumpSound; 
    //the animator to use
    private Animator animator;
    //to initial position to be thrown to
    private Vector3 _initPosition;

    //flags to tell when another animation can play
    private bool _isGrounded = false;
    private bool _animStarted = false;
    private bool _animFinished = true;
    //which key was pressed
    private int _inputKey = 0;
    //the gamerules script
    private GameRules gameRules;

    void Awake()
    {
        //set the animator
        animator = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start ()
    {
        //set initial position
        _initPosition = gameObject.transform.parent.position;
        //add a little on y
        _initPosition.y += 1;
        //set the game rules script
        gameRules = GameObject.FindGameObjectWithTag("Rules").GetComponent<GameRules>();
    }

    // Update is called once per frame
    void Update()
    {
        //all all flags are correct
        if(_animStarted == false && _animFinished == true && _isGrounded == true)
        {
            //check for right arrow
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _inputKey = 3;
            }//check for left arrow
            else
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    _inputKey = 1;
                }//check for up arrow
                else
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        _inputKey = 2;
                    }//check for down arrow
                    else
                    {
                        if (Input.GetKey(KeyCode.DownArrow))
                        {
                            _inputKey = 4;
                        }
                        else
                        {
                            _inputKey = 0;
                        }
                    }
                }
            }
            //play animation
            AnimStart();
        }
    }

    void AnimStart()
    {
        if (_inputKey != 0)
        {
            //set flags so another animation doesn't start
            _animStarted = true;
            _animFinished = false;
            _isGrounded = false;
        }
        //play animation and sound
        animator.SetInteger("AnimState", _inputKey);
        jumpSound.Play();
    }

    //called when animation is finished
    public void SetFinishedTrue()
    {
        //set finished flags
        _animFinished = true;
        _animStarted = false;
        //reset parent position and local position
        myParent.transform.position = transform.position;
        transform.localPosition = Vector3.zero;
    }

    //called when landed on block
    public void IsGrounded()
    {
        //set grounded
        _isGrounded = true;
    }

    //when falling off stage just teleport to top and subtract life
    void OnBecameInvisible()
    {
        //set position
        gameObject.transform.parent.position = _initPosition;
        //subtract life
        gameRules.SubtractLife();
    }

}
