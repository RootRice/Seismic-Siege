using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlockScript : MonoBehaviour
{
    float shieldAngle = 0f;
    PlayerScript myPlayerScript;
    void Start()
    {
        myPlayerScript = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        shieldAngle = myPlayerScript.shieldAngle;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyBullet")
        {
            if (shieldAngle < 359f)
            {
                float hitAngle = Vector3.Angle(new Vector3(myPlayerScript.storedRotation.x, 0f, myPlayerScript.storedRotation.y), new Vector3(other.transform.position.x - gameObject.transform.position.x, 0f, other.transform.position.z - gameObject.transform.position.z));

                if (hitAngle < shieldAngle/2)
                {
                    Destroy(other.gameObject);
                    myPlayerScript.SetRumble(0.5f, 0f);
                }
            }
            else
            {
                Destroy(other.gameObject);
                myPlayerScript.SetRumble(1f, 0f);
            }
        }
    }
}
