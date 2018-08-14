using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public SpawnObject spawnerTwo;
    public SpawnObject spawnerThree;
    public SpawnObject spawnerFour;

    private float minWaitTwo = 1.5f;
    private float maxWaitTwo = 2f;

    private float minWaitThree = 1.5f;
    private float maxWaitThree = 2f;

    private float minWaitFour = 1.5f;
    private float maxWaitFour = 3f;

    private bool isSpawningTwo;
    private bool isSpawningThree;
    private bool isSpawningFour;

    private void Start()
    {
        isSpawningFour = false;
        isSpawningThree = false;
        isSpawningTwo = false;
    }

    // Update is called once per frame
    void Update () {

        if(!isSpawningFour)
        {
            float timer = Random.Range(minWaitFour, maxWaitFour);
            Invoke("SpawnFour", timer);
            isSpawningFour = true;
        }
        if(!isSpawningThree)
        {
            float timer = Random.Range(minWaitThree, maxWaitThree);
            Invoke("SpawnThree", timer);
            isSpawningThree = true;
        }
        if (!isSpawningTwo)
        {
            float timer = Random.Range(minWaitTwo, maxWaitTwo);
            Invoke("SpawnTwo", timer);
            isSpawningTwo = true;
        }
	}

    void SpawnTwo()
    {
        int spawnInd = Random.Range(0, 2);
        float length = Random.Range(1f, 2.5f);
        Vector3 scale = new Vector3(1, length, 1);
        spawnerTwo.Spawn(spawnInd, scale, false);
        isSpawningTwo = false;
    }

    void SpawnThree()
    {
        int spawnInd = Random.Range(0, 2);
        Vector3 scale = new Vector3(1, 1, 1);
        spawnerThree.Spawn(spawnInd, scale, true);
        isSpawningThree = false;
    }

    void SpawnFour()
    {
        Vector3 scale = new Vector3(1, 1, 1);
        spawnerFour.Spawn(0, scale, false);
        isSpawningFour = false;
    }
}
