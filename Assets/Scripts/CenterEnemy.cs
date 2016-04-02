using UnityEngine;
using System.Collections;

public class CenterEnemy : MonoBehaviour {

    //enemy control script
    private EnemyControl enemyControl;

    void Start()
    {
        //set script
        enemyControl = GetComponentInChildren<EnemyControl>();
    }

    void OnCollisionEnter(Collision coll)
    {
        //if grounded
        if (coll.collider.tag.Equals("Terrain"))
        {
            //center on cube
            Vector3 centerPos = new Vector3(coll.gameObject.transform.position.x, transform.position.y, coll.gameObject.transform.position.z);
            transform.position = centerPos;
            //set grounded
            enemyControl.IsGrounded();
        }
    }
}
