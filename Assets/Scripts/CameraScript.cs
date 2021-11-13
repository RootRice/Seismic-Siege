using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    GameObject player;
    Vector2 targetPos;
    [SerializeField] float diagDist = 10;
    Vector3 velocity = Vector3.zero;
    float speed = 0.1f;
    private MasterInput input;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        input = new MasterInput();
        input.Enable();
        input.PlayerMap.Rotate.performed += ctx => targetPos = ctx.ReadValue<Vector2>();
        input.PlayerMap.Rotate.canceled += ctx => targetPos = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(targetPos.x) > Mathf.Abs(targetPos.y))
        {
            if(targetPos.x > 0)
            {
                targetPos = new Vector2(3f, 0f);
            }
            else
            {
                targetPos = new Vector2(-3f, 0f);
            }
        }
        else if(targetPos.magnitude != 0f)
        {
            if (targetPos.y > 0)
            {
                targetPos = new Vector2(0f, 3f);
            }
            else
            {
                targetPos = new Vector2(0f, -3f);
            }
        }
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, player.transform.position + new Vector3(targetPos.x, diagDist, targetPos.y - diagDist), ref velocity, speed*Time.deltaTime, 30f);
    }
}
