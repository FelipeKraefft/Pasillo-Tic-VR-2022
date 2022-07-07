using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuosMovement : MonoBehaviour
{
    public XRNode inputSource;
    public float speed = 1;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public float additionalHeight = 0.2f;
    public CapsuleCollider Capsule;
    public float height = .5f;

    private float fallingSpeed;
    private XRRig rig;
    private Vector2 inputAxis;
    private Vector2 inputAxisRotation;
    private CharacterController character;

    public bool useVRController = false;
    public float movementSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        if (useVRController)
        {
            InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        }
        else
        {
            inputAxis = new Vector2(Input.GetAxis("Horizontal")*movementSpeed,Input.GetAxis("Vertical")*movementSpeed);
            inputAxisRotation = new Vector2(Input.GetAxis("rightXboxHorizontal") * movementSpeed, 0);
        }
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadSet();

        bool isGrounded = CheckIfGrounded();

        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);
        rig.transform.Rotate(0, inputAxisRotation.x, 0);

        //Gravity
        if (isGrounded)
        {
            fallingSpeed = 0;
        }

        else if (!isGrounded)
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
        }
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);

        rig.Camera.transform.position = new Vector3(rig.Camera.transform.position.x, height, rig.Camera.transform.position.z);
    }

    void CapsuleFollowHeadSet()
    {
        character.height = rig.cameraInRigSpaceHeight - additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
        Capsule.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
    }

    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }
}
