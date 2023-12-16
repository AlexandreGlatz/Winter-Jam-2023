using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowball : MonoBehaviour
{
    [SerializeField] Transform player;

    private MeshFilter meshFilter;
    private MeshCollider meshCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TerraformTerrain(player.position, 0.01f, 5);
        }
        if (Input.GetMouseButton(1))
        {
            TerraformTerrain(player.position, -0.01f, 5);
        }
    }

    private Mesh mesh;
    private Vector3[] vertices; 

    private void TerraformTerrain(Vector3 position, float height, float range)
    {
        mesh = meshFilter.sharedMesh;
        vertices = mesh.vertices;
        position -= meshFilter.transform.position;

        int i = 0;
        foreach(Vector3 vert in vertices)
        {
            if (Vector2.Distance(new Vector2(vert.x, vert.z), new Vector2(position.x, position.z)) <= range)
            {
                vertices[i] = vert + new Vector3(0, height, 0); 
            }
            i++; 
        }

        mesh.vertices = vertices;
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }
}
