using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    Ray ray;
    RaycastHit hit;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 100)) 
        {
            lineRenderer.SetPosition(0, cam.transform.position);
            lineRenderer.SetPosition(1, hit.point);
            Debug.Log(hit.transform.name);
        }

        
    }
}
