using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField] private Outline outline = null;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color enterColor = Color.white;
    [SerializeField] private Color downColor = Color.white;
    [SerializeField] private UnityEvent OnClick = new UnityEvent();
    [SerializeField] private Canvas canvas = null;


    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        outline = GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false;
            canvas.enabled = false;
        }
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two) && outline.enabled)
        {
            Debug.Log("B PRESSED");
            canvas.enabled = true;

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        outline.enabled = true; // Enable the outline when pointer enters
        //meshRenderer.material.color = enterColor;
        print("Enter");
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Debug.Log("B PRESSED");
            canvas.enabled = true;

        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (outline != null)
        {
            outline.enabled = false; // Disable the outline when pointer exits
        }
        //meshRenderer.material.color = normalColor;
        print("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //meshRenderer.material.color = downColor;
        print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //meshRenderer.material.color = enterColor;
        print("Up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //OnClick.Invoke();
        print("Click");
    }
}
