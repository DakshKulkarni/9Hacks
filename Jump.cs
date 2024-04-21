using UnityEngine;
using UnityEngine.InputSystem;
public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 targetVelocity; 
    public float acceleration = 10f; 
    public float maxSpeed = 10f; 
    public float turnSpeed = 15f; 
    public float moveSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, acceleration * Time.deltaTime);
    }
    public void Forward(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            targetVelocity = -transform.forward * maxSpeed; 
        }
        else if (context.canceled)
        {
            targetVelocity = Vector3.zero; 
        }
    }
public void LeftTurn(InputAction.CallbackContext context)
{
    if (context.started)
    {
        rb.AddRelativeForce(Vector3.forward *moveSpeed, ForceMode.Acceleration);
        rb.AddTorque(Vector3.up * -turnSpeed*10, ForceMode.Acceleration);
    }
    else if (context.canceled)
    {
        rb.angularVelocity = Vector3.zero;
    }
}
public void RightTurn(InputAction.CallbackContext context)
{
    if (context.started)
    {
        rb.AddRelativeForce(Vector3.forward * moveSpeed, ForceMode.Acceleration);
        rb.AddTorque(-Vector3.up * -turnSpeed*10, ForceMode.Acceleration);
    }
    else if (context.canceled)
    {
        rb.angularVelocity = Vector3.zero;
    }
}
    public void Backward(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            targetVelocity = transform.forward * maxSpeed;
        }
        else if (context.canceled)
        {
            targetVelocity = Vector3.zero;
        }
    }
}