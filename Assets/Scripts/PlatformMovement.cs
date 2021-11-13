using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] Vector3[] positions;
    [SerializeField] bool direction;
    [SerializeField] float timer;
    [SerializeField] float speed;
    

    // Update is called once per frame
    void Update()
    {
        timer += direction ? Time.deltaTime*speed : -Time.deltaTime*speed;
        direction = timer < 0 ? true : direction;
        direction = timer > 1 ? false : direction;
        gameObject.transform.position = Vector3.Lerp(positions[0], positions[1], timer);
    }
}
