using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaserPointer : MonoBehaviour
{
    [SerializeField] [Range(1.0f, 10.0f)] float defaultLength = 5.0f;
    public GameObject dot;
    public VRInputModule m_InputModule;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // Use default or distance
        PointerEventData data = m_InputModule.GetData();
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? defaultLength : data.pointerCurrentRaycast.distance;

        // Raycast
        RaycastHit hit = CreateRaycast(targetLength);

        // Default
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        // Or based on hit
        if (hit.collider != null)
            endPosition = hit.point;

        // Set position of the dot
        dot.transform.position = endPosition;

        // Set LineRenderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }
}
