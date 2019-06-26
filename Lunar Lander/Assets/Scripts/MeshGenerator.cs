using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{

    //Declares our mesh, an array called vertices which stores Vector3s & declares the size of the mesh along the X & Z axis.
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    public int xSize = 20;
    public int zSize = 20;

    public float depth;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent <MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void Update()
    {
        UpdateMesh();
    }

    //
    void CreateShape()
    {
        //Sets our vertices to be the +1 the size of our X & Z components to ensure that our grid is the correct size.
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        //Loops over all of our vertices.
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                //Adjusts the height of the plane using perlin noise, we smooth out this transition over the entire plane.
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f;
                vertices[i] = new Vector3(x, y * depth, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        //Loops over all of our vertices and draws out our terrain.
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                //takes into account
                triangles[0 + tris] = vert + 0;
                triangles[1 + tris] = vert + xSize + 1;
                triangles[2 + tris] = vert + 1;
                triangles[3 + tris] = vert + 1;
                triangles[4 + tris] = vert + xSize + 1;
                triangles[5 + tris] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    //We use gizmos to display the mesh in the editor.
    private void OnDrawGizmos()
    {

        if (vertices == null)
            return;
        
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
}
