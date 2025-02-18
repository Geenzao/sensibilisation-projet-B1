using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float laserDistance = 100f;
    [SerializeField] private LayerMask ignoreMask;
    [SerializeField] private UnityEvent OnHitTarget;

    private RaycastHit rayHit;
    private Ray ray;

    private Vector3 globalPosition;

    private void Awake()
    {
        globalPosition = transform.TransformPoint(Vector3.zero);
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        ray = new Ray(globalPosition, transform.forward);

        if (Physics.Raycast(ray, out rayHit))
        {
            lineRenderer.SetPosition(0, globalPosition);
            lineRenderer.SetPosition(1, rayHit.point);

            // //must have a MonoBehaviour script called Target with public method Hit
            // if (rayHit.collider.TryGetComponent(out Target target))
            // {
            //     target.Hit();
            //     OnHitTarget?.Invoke();
            // }
        }
        else
        {
            lineRenderer.SetPosition(0, globalPosition);
            lineRenderer.SetPosition(1, globalPosition + transform.forward * laserDistance);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.Log(ray.origin);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray.origin, ray.direction * laserDistance);

        Debug.Log(rayHit.point);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rayHit.point,0.23f);
    }
}
