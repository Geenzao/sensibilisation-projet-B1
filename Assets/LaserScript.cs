using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    private Vector3 startPoint;

    void Start() {
        lr = GetComponent<LineRenderer>();
        startPoint = transform.position;
    }

    void Update() {
        lr.SetPosition(0, startPoint);
        RaycastHit hit;
        if (Physics.Raycast(startPoint, transform.up, out hit)) 
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
            if (hit.transform.tag == "Receiver")
            {
                print("false");
            }
        }
        else lr.SetPosition(1, transform.up * 5000);
    }
}
