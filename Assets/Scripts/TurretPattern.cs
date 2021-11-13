using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPattern : MonoBehaviour
{
    float timer = 0f;
    bool rest = false;
    [SerializeField] float waitTime;
    [SerializeField] List<HomingTurret> turrets;

    // Start is called before the first frame update
    void Start()
    {
        foreach (HomingTurret turret in turrets)
        {
            turret.FreezeTimer(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            
            HaltTurrets();
            if (!rest)
            {
                int pattern = Random.Range(0, 2);
                timer = 0f;
                waitTime = Random.Range(4f, 8f);
                rest = true;
                if (pattern == 0)
                {
                    SingleBurst();
                }
                else if (pattern == 1)
                {
                    DiagBurst();
                }
            }
            else
            {
                timer = 0f;
                waitTime = 5f;
                rest = false;
            }
        }
    }

    void SingleBurst()
    {
        foreach(HomingTurret turret in turrets)
        {
            turret.SetPattern(0, 2.5f, false);
        }
    }

    void HaltTurrets()
    {
        foreach(HomingTurret turret in turrets)
        {
            turret.SetPattern(0, 0, true);
        }
    }

    void DiagBurst()
    {
        int index = Random.Range(0, 2);
        turrets[index*2].SetPattern(3, 1.5f, false);
        turrets[LoopIndex((index*2) +1)].SetPattern(3, 1.5f, false);
    }

    int LoopIndex(int num)
    {
        if(num < 0)
        {
            num += turrets.Count;
        }
        else if(num > turrets.Count-1)
        {
            num -= turrets.Count;
        }

        return num;
    }
}
