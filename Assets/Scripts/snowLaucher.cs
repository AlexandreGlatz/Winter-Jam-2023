using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowLaucher : MonoBehaviour
{

    public Transform snowballSpawnpoint;
    public GameObject snowballPrefab;
    public float snowballSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var snowball = Instantiate(snowballPrefab, snowballSpawnpoint.position, snowballSpawnpoint.rotation);
            snowball.GetComponent<Rigidbody>().velocity = snowballSpawnpoint.forward * snowballSpeed;
        }
    }
}
