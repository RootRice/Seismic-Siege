using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuilder : MonoBehaviour
{
    float shieldAngle = 0f;
    float prevAngle =0.0f;
    float meshResolution = 0.05f;

    public MeshFilter shield;
    PlayerScript myPlayerScript;
    Mesh viewMesh;

    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        myPlayerScript = FindObjectOfType<PlayerScript>();
        viewMesh = new Mesh();
        viewMesh.name = "shield mesh";
        shield.mesh = viewMesh;
    }

    // Update is called once per frame
    void Update()
    {
        if(shieldAngle < 10f && myPlayerScript.shieldAngle == 0f)
        {
            shieldAngle = 0f;
            timer = 0f;
            viewMesh.Clear();
        }
        else if(myPlayerScript.shieldAngle != shieldAngle)
        {
            if(prevAngle != myPlayerScript.shieldAngle)
            {
                prevAngle = myPlayerScript.shieldAngle;
                timer = 0f;
            }
            timer += Time.deltaTime*0.3f;
            shieldAngle = Mathf.Lerp(shieldAngle, myPlayerScript.shieldAngle, timer);
            if(shieldAngle > 10)
            {
                DrawShield();
            }
            
        }
        else
        {
            timer = 0f;
        }
    }

    void DrawShield()
    {
        int i;
        Vector3 adjustedWorldPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        int stepCount = Mathf.RoundToInt(shieldAngle * meshResolution);
        float stepAngleSize = shieldAngle / stepCount;
        List<Vector3> conePoints = new List<Vector3>();
        float angle = transform.eulerAngles.y - shieldAngle / 2;

        for (i = 0; i <= stepCount; i++)
        {
            angle = transform.eulerAngles.y - shieldAngle / 2 + stepAngleSize * i;
            conePoints.Add(new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle) * 0.7f, 0f, Mathf.Cos(Mathf.Deg2Rad * angle) * 0.7f));
            conePoints.Add(new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle) * 0.7f, 1f, Mathf.Cos(Mathf.Deg2Rad * angle) * 0.7f));
        }

        //angle = transform.eulerAngles.y - shieldAngle / 2 + stepAngleSize * stepCount;
        //conePoints.Add(new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 1f, Mathf.Cos(Mathf.Deg2Rad * angle)));
        //conePoints.Add(new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0f, Mathf.Cos(Mathf.Deg2Rad * angle)));

        for (i = stepCount; i >= 0; i--)
        {
            angle = transform.eulerAngles.y - shieldAngle / 2 + stepAngleSize * i;
            conePoints.Add(new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0f, Mathf.Cos(Mathf.Deg2Rad * angle)));
            conePoints.Add(new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 1f, Mathf.Cos(Mathf.Deg2Rad * angle)));
        }
       

        int vertexCount = conePoints.Count;
        Vector3[] verticeArray = new Vector3[vertexCount];
        int[] triangles = new int[((vertexCount - 2) * 6) +3];
        verticeArray[0] = conePoints[0];
        
        for (i = 1; i < vertexCount; i++)
        {
            verticeArray[i] = conePoints[i];
        }


        int j = 3;
        //for (i = 6; i + 6 < (vertexCount - 2) * 3; i++)
        //{
        //    triangles[i] = i - j;
        //    i++;
        //    triangles[i] = i + 1 - j;
        //    i++;
        //    triangles[i] = i - 1 - j;
        //    i++;
        //    j++;
        //    triangles[i] = i - j;
        //    i++;
        //    triangles[i] = i - j;
        //    i++;
        //    triangles[i] = i - j - 3;

        //    j += 3;

        //}

        triangles[0] = 1;
        triangles[1] = 2;
        triangles[2] = 0;
        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;
        for (i = 6; i < (vertexCount - 2) * 3; i++)
        {
            triangles[i] = i - j;
            i++;
            triangles[i] = i - j;
            i++;
            triangles[i] = i - j - 3;
            i++;
            j+=3;
            triangles[i] = i - j;
            i++;
            triangles[i] = i + 1 - j;
            i++;
            triangles[i] = i - 1 - j;
            j ++;
        }
        triangles[i] = 0;
        i++;
        triangles[i] = vertexCount-2;
        i++;
        triangles[i] = vertexCount - 1;
        i++;
        triangles[i] = vertexCount - 1;
        i++;
        triangles[i] = 1;
        i++;
        triangles[i] = 0;
        j = 1;
        for(i = i+1; j < (vertexCount -1)/2; i++)
        {
            triangles[i] = vertexCount - j;
            i++;
            triangles[i] = j+2;
            i++;
            triangles[i] = j;
            i++;
            triangles[i] = vertexCount - j;
            i++;
            triangles[i] = vertexCount - 2 - j;
            i++;
            triangles[i] = j + 2;
            j += 2;

            
        }

        viewMesh.Clear();
        viewMesh.vertices = verticeArray;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }
}
