using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelCreator : MonoBehaviour {

    //size of the grid
    public int gridSize = 7;
    //the cube
    public GameObject boxCube;

    //private Vector3 _initialPosition = new Vector3(-4.25f, -4, 0);
    private Vector3 _initialPosition;
    private Vector3 _lastPosition;
    private List<List<GameObject>> _mapList;

    // Use this for initialization
    void Start () {
        _initialPosition = boxCube.transform.position;
        CreateGrid();
    }

    //creates all rows of the level
    void CreateGrid()
    {
        int rowSize = gridSize;
        for(int i = 0; i < gridSize; ++i)
        {
            _lastPosition = _initialPosition;
            for (int j = 0; j < rowSize; ++j)
            {
                 Instantiate(boxCube, _lastPosition, boxCube.transform.rotation);
                //move right
                _lastPosition.x += 1.408f;
            }
            //less in next row
            --rowSize;
            //move accordinly
            _initialPosition.x += 0.701f;
            _initialPosition.y += 0.996f;
            _initialPosition.z += 0.714f;
        }
    }

}
