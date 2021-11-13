using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDestroyer : MonoBehaviour
{
    [SerializeField] List<GameObject> defenders;

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject enemy in defenders)
        {
            if(enemy == null)
            {
                defenders.Remove(enemy);
            }
        }
        if(defenders.Count == 0)
        {
            Destroy(gameObject);
        }
    }
}
