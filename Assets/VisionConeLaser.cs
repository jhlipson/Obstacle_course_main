using UnityEngine;

public class VisionConeLaser : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    public Transform Player;
    Ray ray;
    RaycastHit hit;
    Vector3 startingPos = Vector3.zero;
    Vector3 endPosition = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        startingPos = transform.position;
        endPosition = Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRayData();
    }

    private void UpdateRayData()
    {

        if (_lineRenderer != null)
        {
            Vector3 rayNewPosition = endPosition - startingPos;
            Ray rayCast = new Ray(startingPos, rayNewPosition.normalized);
            if (Physics.Raycast(rayCast, out hit))
            {
                Debug.DrawRay(hit.point, hit.normal);
               
            }
        }
    }
}
