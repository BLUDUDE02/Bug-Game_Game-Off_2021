using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHandler : MonoBehaviour
{
    public Color startcolor;
    public Color selected;

    private float currentY;
    public float sensivity = 2500.0f;

    private Renderer renderer;

    private Vector3 screenPoint;
    private Vector3 offset;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        renderer.material.color = selected;
    }
    private void OnMouseExit()
    {
        renderer.material.color = startcolor;
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = new Vector3(0, curPosition.y, 0);
    }
}
