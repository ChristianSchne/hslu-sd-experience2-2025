using UnityEngine;
using UnityEngine.Events;


public class StickOnCollision : MonoBehaviour
{
    private Rigidbody rb;
    private bool isSliding = false;
    public float minImpactStrength = 1.0f;

    public float slideSpeed = 0.005f; // Adjust this value for desired sliding deceleration

    public float stickyness = 0.5f; // Adjust this value for desired sliding deceleration

    public UnityEvent onCollision;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Calculate the collision's relative velocity magnitude
        float impactStrength = collision.relativeVelocity.magnitude;

        // Check if the impact strength is greater than or equal to the minimum required strength
        if (impactStrength >= minImpactStrength)
        {
            

            // Calculate the rotation needed to align the object with the hit surface's normal
            Quaternion rotationToSurface = Quaternion.FromToRotation(transform.up, collision.contacts[0].normal);

            // Apply the rotation to make the object lay flat on the surface
            transform.rotation = rotationToSurface * transform.rotation;


            Destroy(GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>());

            // Disable the object's Rigidbody physics to make it stay flat
            rb.isKinematic = true;

            // Set the object as sliding
            isSliding = true;


            // Invoke the custom UnityEvent
            onCollision.Invoke();
        }
    }

    private void Update()
    {
        if (isSliding)
        {

            rb.MovePosition(rb.position + Vector3.down * slideSpeed);
            slideSpeed *= 1 - Time.deltaTime * stickyness;



        }
    }
}
