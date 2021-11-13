using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeBuilder : MonoBehaviour
{
    float viewAngle = 5f;
    float prevAngle = 5f;
    float targetAngle = 5f;
    float meshResolution = 1;
    float coneDist = 90;
    float angleTimer = 0;

    public MeshFilter cone;
    PlayerScript myPlayerScript;
    Mesh viewMesh;
    // Start is called before the first frame update
    void Start()
    {
        myPlayerScript = FindObjectOfType<PlayerScript>();
        viewMesh = new Mesh();
        viewMesh.name = "cone mesh";
        cone.mesh = viewMesh;
    }

    // Update is called once per frame
    void Update()
    {
        targetAngle = myPlayerScript.maxOffsetValue;
        
        if (targetAngle != viewAngle)
        {
            if(targetAngle != prevAngle)
            {
                angleTimer = 0f;
                prevAngle = targetAngle;
            }
            angleTimer += Time.deltaTime;
            viewAngle = Mathf.Lerp(viewAngle, targetAngle, angleTimer);
            DrawFieldOfView();
        }
        else
        {
            angleTimer = 0f;
        }
    }

    void DrawFieldOfView()
    {
        Vector3 adjustedWorldPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> conePoints = new List<Vector3>();
        conePoints.Add(Vector3.zero);
        for(int i = 1; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
            conePoints.Add(new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0f, Mathf.Cos(Mathf.Deg2Rad * angle))*55f );
        }
        int vertexCount = conePoints.Count;
        Vector3[] verticeArray = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];
        for (int i = 0; i < vertexCount; i++)
        {
            verticeArray[i] = conePoints[i];
            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }
        viewMesh.Clear();
        viewMesh.vertices = verticeArray;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }
}
