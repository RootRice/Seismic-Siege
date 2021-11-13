using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingTurret : MonoBehaviour
{
    GameObject playerCharacter;
    GameObject turret;
    [SerializeField] float fireTimer= 0f;
    [SerializeField] float fireRate;
    public GameObject bullet;
    int bulletCounter = 0;
    [SerializeField] int clipSize;
    int hp = 45;
    float hitColour = 0;

    MeshRenderer myRenderer;

    bool frozen = false;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        foreach(Transform child in gameObject.GetComponentInChildren<Transform>())
        {
            if(child.localPosition.y == 0.25f)
            {
                turret = child.gameObject;
            }
        }
    }

    void Update()
    {
        if (Vector3.Magnitude(gameObject.transform.position - new Vector3(0f, 1f, 0f) - playerCharacter.transform.position) < 30f)
        {
            RaycastHit hit;
            if(Physics.Raycast(gameObject.transform.position, playerCharacter.transform.position - gameObject.transform.position + new Vector3(0, 1f, 0), out hit, 30f))
            {
                if(hit.collider.tag == "Player")
                {
                    AimTurret();
                    if(!frozen)
                    {
                        Fire();
                    }
                }
            }
        }
        if(hitColour > 0)
        {
            hitColour-= Time.deltaTime;
        }
        else
        {
            hitColour = 0;
        }
        myRenderer.material.color = Vector4.Lerp(new Vector4(1, 1, 1, 1), new Vector4(1, 0, 0, 1), hitColour);
    }

    void Fire()
    {
        fireTimer += Time.deltaTime;
        if(fireTimer > fireRate)
        {
            Instantiate(bullet, turret.transform.position, Quaternion.Euler(90f, 0f, -turret.transform.rotation.eulerAngles.y + 90));
            bulletCounter += 1;
            if(bulletCounter > clipSize)
            {
                bulletCounter = 0;
                fireTimer -= fireRate;
            }
            else
            {
                fireTimer = fireRate - 0.3f;
            }
        }
    }

    public void FreezeTimer(bool mode)
    {
        frozen = mode;
    }

    public bool PollFiring()
    {
        return bulletCounter > 0;
    }
    void AimTurret()
    {
        Vector3 playerDir = gameObject.transform.position - new Vector3(0f, 1f, 0f) - playerCharacter.transform.position ;
        float yAngle = Mathf.Acos(playerDir.x / playerDir.magnitude); ;
        if (playerDir.z < 0f)
        {
            yAngle = yAngle * Mathf.Rad2Deg;
        }
        else
        {
            yAngle = - yAngle * Mathf.Rad2Deg;
        }

        turret.transform.rotation = Quaternion.Euler(new Vector3(0f, yAngle, 90f));
    }

    public void SetPattern(int cSize, float fRate, bool mode)
    {
        clipSize = cSize;
        fireRate = fRate;
        fireTimer = fRate;
        frozen = mode;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerBullet")
        {
            hp -= 1;
            Destroy(other.gameObject);
            if(hp < 1)
            {
                Destroy(gameObject);
            }
            hitColour = 1;
        }
    }
}
