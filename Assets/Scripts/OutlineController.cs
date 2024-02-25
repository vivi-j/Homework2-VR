using UnityEngine;

public class OutlineController : MonoBehaviour
{
    public Outline outline; 
    public LineRenderer lineRenderer = null;

    public void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    void Update()
    {
        if (IsControllerPointingAtSphere())
        {
            // Enable the outline script
            outline.enabled = true;
        }
        else
        {
            // Disable the outline script
            outline.enabled = false;
        }
    }

    bool IsControllerPointingAtSphere()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }
        return false;
    }


}
