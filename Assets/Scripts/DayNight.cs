using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class DayNight : MonoBehaviour
{

    public float rotationSpeed = 1.0f;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

}
