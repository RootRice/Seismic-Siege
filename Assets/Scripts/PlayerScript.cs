using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private MasterInput input;
    Gamepad gamepad;
    GameObject tankBase;
    GameObject tankCannon;
    [SerializeField] GameObject shieldBar;
    [SerializeField] GameObject bullet;
    GameObject[] legs = new GameObject[4];
    Vector3[] legPositions = new Vector3[4];
    float legProtursion = 0f;
    bool hit = true;

    private Vector2 movementRate;
    float movementAngle = 0;

    Vector2 rotationRate = new Vector2(0, 1);
    public Vector2 storedRotation = new Vector2(0, 1);
    public float rotationAngle = 0;

    public float offset;
    public float maxOffsetValue = 20f;
    float firingRate = 0.0f;
    float fireTimer = 0.0f;
    float lockedRate = 360.0f;

    float shieldAngleScalar = 0.0f;
    public float shieldAngle = 0.0f;
    float shieldEnergy = 100.0f;

    float stability = 1f;

    bool siegeMode = false;

    public int hp = 10;

    MeshRenderer myRenderer;
    float hitColour = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        SetInputs();
        RetrieveObjects();
        myRenderer = tankBase.GetComponent<MeshRenderer>();
    }

    void RetrieveObjects()
    {
        int legC = 0;
        foreach(Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            if(child.localPosition.y == 1f)
            {
                tankBase = child.gameObject;
            }
            else if(child.localPosition.y == 1.5f)
            {
                tankCannon = child.gameObject;
            }
            else if(child.localPosition.y == -0.71f)
            {
                legs[legC] = child.gameObject;
                legPositions[legC] = child.transform.localPosition;
                legC++;
            }
            else if(child.localPosition.z == 1f)
            {

            }
        }
    }

    void SetInputs()
    {
        input = new MasterInput();
        input.Enable();
        input.PlayerMap.Move.performed += ctx => ReadMove(ctx.ReadValue<Vector2>());
        input.PlayerMap.Move.canceled += ctx => ReadMove(Vector2.zero);
        input.PlayerMap.Rotate.performed += ctx => ReadRotate(ctx.ReadValue<Vector2>());
        input.PlayerMap.Rotate.canceled += ctx => ReadRotate(Vector2.zero);
        input.PlayerMap.Cannon.performed += ctx => ReadCannon(ctx.ReadValue<float>());
        input.PlayerMap.Cannon.canceled += ctx => ReadCannon(0f);
        input.PlayerMap.Shield.performed += ctx => ReadShield(ctx.ReadValue<float>());
        input.PlayerMap.Shield.canceled += ctx => ReadShield(0);
        input.PlayerMap.SiegeMode.performed += ctx => ReadSiege();
        input.PlayerMap.LockRate.performed += ctx =>  lockedRate = (firingRate > 0f)? firingRate : 360f;
        gamepad = Gamepad.current;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(hp <= 0)
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
        if(InputSystem.GetDevice<Keyboard>().escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
        if (!siegeMode)
        {
            if (shieldEnergy < 100f)
            {
                shieldEnergy += 7.5f * Time.fixedDeltaTime;
            }
            else
            {
                shieldEnergy = 100f;
            }
            shieldBar.transform.localScale = new Vector3(shieldEnergy / 100, 1f, 1f);
            Move();
            legProtursion = Mathf.Clamp(legProtursion -= Time.fixedDeltaTime, 0f, 1f);
        }
        else
        {
            legProtursion = Mathf.Clamp(legProtursion += Time.fixedDeltaTime * 5f, 0f, 1f);
            Shield();
        }
        if(legProtursion != 0f && legProtursion != 1f)
        {
            for(int i = 0; i < 4; i++)
            {
                legs[i].transform.localPosition = Vector3.Lerp(legPositions[i], legPositions[i] * 1.5f, legProtursion);
            }
        }
        Rotate();
        Shoot();
        if (hitColour > 0)
        {
            hitColour -= Time.fixedDeltaTime;
        }
        else if(hit)
        {
            hit = false;
            hitColour = 0;
            gamepad.SetMotorSpeeds(0f, 0f);
        }
        myRenderer.material.color = Vector4.Lerp(new Vector4(1, 1, 1, 1), new Vector4(1, 0, 0, 1), hitColour);
    }

    void Shield()
    {
        if (shieldEnergy > 0f)
        {
            if (shieldAngleScalar == 1f)
            {
                shieldAngle = 360f;
                shieldEnergy -= 60f * Time.fixedDeltaTime;
            }
            else if (shieldAngleScalar > 0.55f)
            {
                shieldAngle = 180f;
                shieldEnergy -= 30f * Time.fixedDeltaTime;
            }
            else if (shieldAngleScalar > 0.05f)
            {
                shieldAngle = 90f;
                shieldEnergy -= 15f * Time.fixedDeltaTime;
            }
            else
            {
                shieldAngle = 0;
                if (shieldEnergy < 100f)
                {
                    shieldEnergy += 22.5f * Time.fixedDeltaTime;
                }
                else
                {
                    shieldEnergy = 100f;
                }
            }
        }
        else if(shieldAngleScalar == 0)
        {
            shieldAngle = 0;
            shieldEnergy += 7.5f * Time.fixedDeltaTime;
         
        }
        else
        {
            
            shieldAngle = 0;
        }
        shieldBar.transform.localScale = new Vector3(shieldEnergy / 100, 1f, 1f);
    }

    void Shoot()
    {
        float firingRateHolder = firingRate;
        if(firingRate > 0.0f)
        {
            if (firingRate > 0.99f)
            {
                firingRateHolder = 0.1f;
                offset = Random.Range(-25f/stability, 25f / stability);
                maxOffsetValue = 50f / stability;
            }
            else if (firingRate > 0.15f)
            {
                firingRateHolder = 0.15f;
                offset = 0.75f * Random.Range(-9.5f / stability, 9.5f / stability);
                maxOffsetValue = 20f / stability;
            }
            else
            {
                firingRateHolder = 0.3f;
                offset = 0;
                maxOffsetValue = 2.5f;
            }


            fireTimer += Time.deltaTime;
            if (fireTimer >firingRateHolder)
            {
                Instantiate(bullet, tankCannon.transform.position + new Vector3(storedRotation.x * Mathf.Cos(offset * Mathf.Deg2Rad) - storedRotation.y * Mathf.Sin(offset * Mathf.Deg2Rad), 0f, storedRotation.x * Mathf.Sin(offset * Mathf.Deg2Rad) + storedRotation.y * Mathf.Cos(offset * Mathf.Deg2Rad)), Quaternion.Euler(90f, 0f, -rotationAngle + offset));
                fireTimer = 0.0f;
            }
        }
        else
        {
            fireTimer = 0.0f;
        }
    }

    void Move()
    {
        float movementSpeed = 5f;
        Vector3 direction = new Vector3(movementRate.x, 0f, movementRate.y) * movementSpeed * Time.fixedDeltaTime;
        if (movementRate.magnitude > 0.15f)
        {
            movementAngle = Vector3.Angle(new Vector3(0f, 0f, 1f), direction);
            if (movementRate.x < 0)
            {
                movementAngle = 360 - movementAngle;
            }
            tankBase.transform.rotation = Quaternion.RotateTowards(tankBase.transform.rotation, Quaternion.Euler(0f, movementAngle, 0f), 300 * Time.fixedDeltaTime);
        }
        gameObject.transform.position += direction;
    }

    void Rotate()
    {
        Vector3 direction = new Vector3(rotationRate.x, 0f, rotationRate.y);

        if (rotationRate.magnitude > 0.15f)
        {
            rotationAngle = Vector3.Angle(new Vector3(0f, 0f, 1f), direction);
            if (rotationRate.x < 0)
            {
                rotationAngle = 360 - rotationAngle;
            }
        }
        tankCannon.transform.rotation = Quaternion.RotateTowards(tankCannon.transform.rotation, Quaternion.Euler(0f, rotationAngle, 0f), 900 * Time.fixedDeltaTime);
        
    }

    void ReadShield(float coverage)
    {
        shieldAngleScalar = coverage;
        if(coverage == 0)
        {
            shieldAngle = 0;
        }
    }

    void ReadCannon(float rate)
    {
        if (rate <= lockedRate)
        {
            firingRate = rate;
        }
        if(rate == 0f)
        {
            lockedRate = 360f;
            firingRate = 0f;
            maxOffsetValue = 1.5f;
        }
    }

    void ReadMove(Vector2 movement)
    {
        movementRate = movement;
    }

    void ReadRotate(Vector2 rotation)
    {
        if(rotation.magnitude > 0.15f)
        {
            storedRotation = rotation.normalized;
        }
        rotationRate = rotation;
    }

    void ReadSiege()
    {
        siegeMode = !siegeMode;
        if (stability == 1f)
        {
            stability = 2f;
        }
        else
        {
            stability = 1f;
            shieldAngle = 0f;
        }
    }

    public void SetRumble(float low, float high)
    {
        gamepad.SetMotorSpeeds(low, high);
        hit = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyBullet")
        {
            hp -= 1;
            other.tag = "Destructible";
            gamepad.SetMotorSpeeds(0, 1f/hp);
            Destroy(other.gameObject);
            hitColour = 1;
            hit = true;
        }
    }
}
