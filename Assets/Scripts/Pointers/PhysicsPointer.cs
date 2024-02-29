using UnityEngine;

public class PhysicsPointer : MonoBehaviour
{
    public float defaultLength = 3.0f;
    public LineRenderer left;
    public LineRenderer right;


    private void Awake()
    {
        
    }

    private void Update()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        left.SetPosition(0, transform.position);
        left.SetPosition(1, CalculateEnd());

        right.SetPosition(0, transform.position);
        right.SetPosition(1, CalculateEnd());

    }

    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endPosition = DefaultEnd(defaultLength);

        if (hit.collider)
            endPosition = hit.point;
        return endPosition;
    }

    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, defaultLength);
        return hit;
    }

    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }
}
