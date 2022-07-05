using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerControllerNew : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rb;
    public Transform visorTR;
    public float visorY;
    public float offsetAngle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion Angles = InputTracking.GetLocalRotation(XRNode.Head);
        transform.rotation = Quaternion.Euler(0, Angles.eulerAngles.y * offsetAngle, 0);

        rb.velocity = Vector3.forward * Input.GetAxis("Vertical") * speed;
        //transform.localEulerAngles = new Vector3(0f,visorTR.eulerAngles.y,0f);
        //visorY = visorTR.rotation.y;
    }
}
