using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyControl : MonoBehaviour {

    //parent to move according to
    public GameObject myParent;
    //the position of the player
    public GameObject playerPos;
    //jump sound to play
    public AudioSource jumpSound;
    //animator to use
    private Animator _animator;
    //flags to use
    private bool _animStarted = false;
    private bool _animFinished = true;
    //left or right call to animator
    private int _GO_LEFT = 1;
    private int _GO_RIGHT = 2;
    //has enemy landed
    private bool _isGrounded;
    //game rules script
    private GameRules gameRules;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
        gameRules = GameObject.FindGameObjectWithTag("Rules").GetComponent<GameRules>();
    }
	
	// Update is called once per frame
	void Update () {

        //check if flags are good
        if (_animStarted == false && _animFinished == true && _isGrounded == true)
        {
            //choose direction based on player position
            if(transform.position.x > playerPos.transform.position.x)
            {
                AnimStart(_GO_LEFT);
            }
            else
            {
                AnimStart(_GO_RIGHT);
            }
        }
    }

    //start the animation
    void AnimStart(int dir)
    {
        _animStarted = true;
        _animFinished = false;
        _isGrounded = false;
        _animator.SetInteger("LR_Input", dir);
        jumpSound.Play();
    }

    //once done call
    public void SetFinishedTrue()
    {
        _animFinished = true;
        _animStarted = false;
        //reset position
        myParent.transform.position = transform.position;
        transform.localPosition = Vector3.zero;
    }

    public void IsGrounded()
    {
        //set grounded
        _isGrounded = true;
    }

    //if it hits the player sutract a life and delete all current enemies on screen
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag.Equals("Player"))
        {
            gameRules.SubtractLife();

            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(go);
            } 
        }
    }

    //when falling off delete it
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        //destroy parent when child is destroyed
        Destroy(transform.parent.gameObject);
    }
}
