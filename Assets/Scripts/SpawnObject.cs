using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject[] curObject;
    public Vector3[] spawnPos;

    public static List<float> notUsed = new List<float>(){0.5f, 1f, 1.5f, 2f, 2.5f, 3f, 3.5f, 4f, 4.5f, 5f};
    public static List<float> used = new List<float>();

    public void Start()
    {
        InvokeRepeating("Reuse", 4f, 4f);
    }

    void Reuse()
    {
        if(used.Count >= 1)
        {
            notUsed.Add(used[0]);
            used.RemoveAt(0);
        }
    }

    public void Spawn(int spawnIndex, Vector3 scale, bool rando)
    {
        if (rando)
        {
            int ind = Random.Range(0, notUsed.Count);
            spawnPos[spawnIndex].y = notUsed[ind];
            used.Add(notUsed[ind]);
            notUsed.RemoveAt(ind);
        }
        GameObject curobj = Instantiate(curObject[spawnIndex], spawnPos[spawnIndex], Quaternion.identity);
        curobj.transform.localScale = scale;
    }
}
