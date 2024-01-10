using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowLauncher : MonoBehaviour
{

    public GameObject inventory;

    public float maxSnow;
    public float snowAmount;
    public float snowballCost;
    public LoadingBar bar;

    public Vector3 baseForces;

    public Transform snowballSpawnpoint;
    public GameObject snowballPrefab;
    public float snowballSpeed = 10;

    public void Start()
    {
        bar.UpdateBar(snowAmount / maxSnow, maxSnow);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (inventory.activeSelf)
            {
                return;
            }

            if (snowAmount < snowballCost)
            {
                return;
            }

            var snowball = Instantiate(snowballPrefab, snowballSpawnpoint.position, snowballSpawnpoint.rotation);
            snowball.GetComponent<Rigidbody>().velocity = snowballSpawnpoint.forward * snowballSpeed + baseForces;
            snowball.SetActive(true);
            bar.UpdateBar(snowAmount / maxSnow, maxSnow);
            snowAmount -= snowballCost;
        }

        if (snowAmount < maxSnow)
        {
            ReloadSnow(0.02f);
        }
    }

    public void ReloadSnow(float amount)
    {
        if (snowAmount < maxSnow)
        {
            snowAmount += amount;
            bar.UpdateBar(snowAmount / maxSnow, maxSnow);
        }
    }

}
