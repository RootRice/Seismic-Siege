using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    [SerializeField] bool shouldHome;
    Vector3 direction;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, 3f);
        direction = Vector3.Normalize(player.position - transform.position + new Vector3(0f,1.25f,0f));
    }

    // Update is called once per frame
    void Update()
    {
        direction = (shouldHome) ? Vector3.Normalize(player.position - transform.position + new Vector3(0f, 1.25f, 0f)) : direction;
        transform.position += direction * 10f * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }
}
