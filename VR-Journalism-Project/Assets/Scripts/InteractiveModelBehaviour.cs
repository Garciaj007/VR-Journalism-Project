using UnityEngine;

public class InteractiveModelBehaviour : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 1.0f;
    [SerializeField] private float arrivalDistance = 1.0f;
    [SerializeField] private float maxAngularSpeed = 1.0f;
    [Range(0.0f, 0.1f)]
    [SerializeField] private float angularSpeed = 0.01f;
    [SerializeField] private ForceMode forceMode;

    private Rigidbody rigid = null;
    private Vector3 origin = Vector3.zero;
    private Vector3 torque = Vector3.zero;

    public bool IsInManipulationMode { set; private get; }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        origin = transform.position;
    }

    void FixedUpdate()
    {
        if (IsInManipulationMode)
        {
            torque = Vector3.zero;
            return;
        }
        
        var desired = origin - transform.position;
        var distance = desired.magnitude;
        desired = distance < arrivalDistance
            ? desired.normalized * Utils.Mathf.Map(distance, 0, arrivalDistance, 0, maxSpeed)
            : desired.normalized * maxSpeed;
        
        desired *= Time.deltaTime;

        torque += Vector3.up * Time.deltaTime * Mathf.Deg2Rad * angularSpeed;
        
        rigid.AddForce(desired);
        rigid.AddTorque(torque, forceMode);

        rigid.angularVelocity = rigid.angularVelocity.magnitude > maxAngularSpeed
            ? rigid.angularVelocity.normalized * maxAngularSpeed 
            : rigid.angularVelocity;
    }
}
