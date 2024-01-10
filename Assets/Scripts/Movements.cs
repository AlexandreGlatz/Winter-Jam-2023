using UnityEngine;

public class Movements : MonoBehaviour
{

    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObject;
    public Transform bottomSnowSphere;
    public Rigidbody rb;

    public float rotationSpeed;
    public float moveSpeed;

    public SnowLauncher snowLauncher;

    public Vector3 totalForces = Vector3.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {

        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDirection != Vector3.zero)
        {

            playerObject.forward = Vector3.Slerp(playerObject.forward, inputDirection.normalized, rotationSpeed * Time.deltaTime);

            snowLauncher.ReloadSnow(0.03f);
        } else
        {
            totalForces = Vector3.Lerp(totalForces, Vector3.zero, 0.2f);
        }
        print(totalForces);

        var moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if ( (totalForces.x > -moveSpeed && totalForces.z > -moveSpeed) && (totalForces.x < moveSpeed && totalForces.z < moveSpeed) )
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            totalForces = Vector3.Lerp(totalForces, Vector3.zero, 0.05f);
        }
        totalForces += rb.GetAccumulatedForce();

        bottomSnowSphere.forward = viewDirection.normalized;
        var rotationDirection = new Vector3(1.0f * moveDirection.normalized.x, 0.0f, 0.0f);
        bottomSnowSphere.Rotate(rotationDirection);

    }

}
