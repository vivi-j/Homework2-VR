using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRendererLeft;
    [SerializeField] private LineRenderer lineRendererRight;
    public Transform controllerLeft;
    public Transform controllerRight;

    // Update is called once per frame
    void Update()
    {
        // Cast a ray from the left controller
        RaycastFromController(controllerLeft, lineRendererLeft);

        // Cast a ray from the right controller
        RaycastFromController(controllerRight, lineRendererRight);
    }

    void RaycastFromController(Transform controller, LineRenderer lineRenderer)
    {
        if (controller == null || lineRenderer == null)
        {
            return;
        }

        RaycastHit hit;
        Vector3 startPos = controller.position;
        Vector3 endPos = controller.position + controller.forward * 100f; // Assuming the maximum length of the raycast

        if (Physics.Raycast(controller.position, controller.forward, out hit, 100f))
        {
            endPos = hit.point;
        }

        // Update the line renderer positions
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
