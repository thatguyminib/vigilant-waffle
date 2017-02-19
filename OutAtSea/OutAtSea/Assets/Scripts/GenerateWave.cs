using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWave : MonoBehaviour {

    [Range(0.1f, 20.0f)]
    public float heightScale = 5f;
    [Range(0.1f, 40.0f)]
    public float detailScale = 5f;

    private Mesh myMesh;
    private Vector3[] vertices;

    private void Update()
    {
        Generate();

        if (Input.GetKeyDown("space"))
        {
            
        }
        //waveSpeed -= .001f;
    }

    void Generate()
    {
        myMesh = this.GetComponent<MeshFilter>().mesh;
        vertices = myMesh.vertices;

        int counter = 0;//i
        int yLevel = 0;//j

        for(int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                CalculationMethod(counter, yLevel); // changing verts here and applying them
                counter++;
            }
            yLevel++;
        }
        myMesh.vertices = vertices;
        myMesh.RecalculateBounds();
        myMesh.RecalculateNormals();

        Destroy(gameObject.GetComponent<MeshCollider>());
        MeshCollider collider = gameObject.AddComponent<MeshCollider>();
        collider.sharedMesh = null;
        collider.sharedMesh = myMesh;
    }

    public bool waves = false;
    public float waveSpeed = 5;
    void CalculationMethod(int i, int j)
    {
        if (waves)
        {
            vertices[i].z = Mathf.PerlinNoise(Time.time/waveSpeed + (vertices[i].x + transform.position.x) / detailScale, Time.time / waveSpeed + (vertices[i].y + transform.position.y) / detailScale) * heightScale;
            vertices[i].z -= j;
        } else if(!waves){
            vertices[i].z = Mathf.PerlinNoise(Time.time / waveSpeed + (vertices[i].x + transform.position.x) / detailScale, Time.time / waveSpeed + (vertices[i].y + transform.position.y) / detailScale) * heightScale;
            vertices[i].z -= j;
        }
    }

    
}
