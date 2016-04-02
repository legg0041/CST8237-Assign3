using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    //the gameobject to move
    public GameObject playerPosition;
    //the position to move to
    private Vector3 _initPosition;

    // Use this for initialization
    void Start ()
    {
        //set the initial position
        _initPosition = GameObject.FindGameObjectWithTag("PlayerParent").transform.position;
    }

    void OnCollisionEnter(Collision coll)
    {
        //if its the player
        if (coll.collider.name.StartsWith("Player"))
        {
            //set new position
            playerPosition.transform.position = _initPosition;
            //destroy platform
            Destroy(gameObject);
        }
    }
}
