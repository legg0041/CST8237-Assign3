using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    //the left and right spawn points
    public GameObject leftSpawner;
    public GameObject rightSpawner;
    //the prefab to spawn
    public GameObject enemyToSpawn;
    //spawn sound
    public AudioSource spawnSound;
    //delays on spawning enemies
    private float _firstDelay = 2.0f;
    private float _restDelays = 3.0f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", _firstDelay, _restDelays);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnEnemy()
    {
        //position to use
        Transform posToUse;
        //random left or right spawner
        if (Random.value < 0.5f)
        {
            posToUse = leftSpawner.transform;
        }
        else
        {
            posToUse = rightSpawner.transform;
        }
        //play spawn sound ans spawn it
        spawnSound.Play();
        Instantiate(enemyToSpawn, posToUse.position, enemyToSpawn.transform.rotation);
    }


}
