using UnityEngine;

public class JumpPad : UtilObject
{
    [SerializeField] public float bounceForce;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}
