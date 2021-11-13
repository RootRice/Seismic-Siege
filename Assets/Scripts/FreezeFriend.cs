using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeFriend : MonoBehaviour
{
    HomingTurret myTurret;
    [SerializeField] HomingTurret friend;
    // Start is called before the first frame update
    void Start()
    {
        myTurret = gameObject.GetComponent<HomingTurret>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myTurret.PollFiring())
        {
            friend.FreezeTimer(true);
        }
        else
        {
            friend.FreezeTimer(false);
        }
    }

    private void OnDestroy()
    {
        friend.FreezeTimer(false);
    }
}
