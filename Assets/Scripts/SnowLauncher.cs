using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowLauncher : MonoBehaviour
{
    public Transform snowballSpawnPoint;
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
            var snowball = Instantiate(snowballPrefab, snowballSpawnPoint.position, snowballSpawnPoint.rotation);
            snowball.GetComponent<Rigidbody>().velocity = snowballSpawnPoint.forward * snowballSpeed;
        }
    }
}
