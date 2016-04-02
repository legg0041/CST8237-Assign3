using UnityEngine;
using System.Collections;

public class CenterParent : MonoBehaviour {
    //the player control script
    private PlayerControl playerControl;

    void Start()
    {
        //get the script
       playerControl = GetComponentInChildren<PlayerControl>();
    }

    void OnCollisionEnter(Collision coll)
    {
        //when landing on a cube
        if (coll.collider.tag.Equals("Terrain"))
        {
            //align it with the cube to keep centered
            Vector3 centerPos = new Vector3(coll.gameObject.transform.position.x, transform.position.y, coll.gameObject.transform.position.z);
            transform.position = centerPos;
            //set grounded flag
            playerControl.IsGrounded();
        }
    }
}
