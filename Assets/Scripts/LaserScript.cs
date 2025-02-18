using UnityEngine;

public class LaserScript : IChallenge
{
    private LineRenderer lr;
    [SerializeField]
    private Vector3 startPoint;

    private bool _isCompleted;

    override public bool IsCompleted
    {
        get => _isCompleted;
    }

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
            _isCompleted = !(hit.transform.tag == "Receiver");
        }
        else lr.SetPosition(1, transform.up * 5000);
    }
}
