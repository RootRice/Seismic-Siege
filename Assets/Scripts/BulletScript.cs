using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float timer = 0.0f;
    float offSetAngle = 0.0f;
    PlayerScript myPlayerScript;
    Vector3 direction = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
        myPlayerScript = FindObjectOfType<PlayerScript>();
        offSetAngle = myPlayerScript.offset;

        Vector3 adjustedPoint = new Vector3(myPlayerScript.storedRotation.x * Mathf.Cos(offSetAngle * Mathf.Deg2Rad) - myPlayerScript.storedRotation.y * Mathf.Sin(offSetAngle * Mathf.Deg2Rad), 0f, myPlayerScript.storedRotation.x * Mathf.Sin(offSetAngle * Mathf.Deg2Rad) + myPlayerScript.storedRotation.y * Mathf.Cos(offSetAngle * Mathf.Deg2Rad));
        direction = adjustedPoint * 75f;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        gameObject.transform.position += direction * Time.deltaTime;
        if (timer > 0.7f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }
}
