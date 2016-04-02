using UnityEngine;
using System.Collections;

public class SpinEnemy : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        //rotate on y axis
        transform.Rotate(0, 180 * Time.deltaTime, 0, Space.World);
	}
}
