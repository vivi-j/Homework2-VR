using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 3.0f;
    public Transform characterTransform;

    // Update is called once per frame
    void Update()
    {
        Vector2 leftPrimaryAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
        Vector2 rightPrimaryAxis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);

        Vector2 primaryAxis = leftPrimaryAxis + rightPrimaryAxis;

        if (primaryAxis.magnitude > 1)
        {
            primaryAxis.Normalize();
        }

        Vector3 movementDirection = transform.right * primaryAxis.x + transform.forward * primaryAxis.y;
        characterTransform.position += movementDirection * speed * Time.deltaTime;
        float fixedY = characterTransform.position.y;
        characterTransform.position = new Vector3(characterTransform.position.x, fixedY, characterTransform.position.z);
    }
}
