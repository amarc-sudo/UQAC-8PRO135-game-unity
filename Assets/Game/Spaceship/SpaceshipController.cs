using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 20f;
    [SerializeField]
    private float hoverSpeed = 20f;
    [SerializeField]
    private float strafeSpeed = 20f;
    [SerializeField]
    private float movementSpeedAcceleration = 3f;
    [SerializeField]
    private float hoverSpeedAcceleration = 2f;
    [SerializeField]
    private float strafeSpeedAcceleration = 2f;
    [SerializeField]
    private float currentMovementSpeed;
    [SerializeField]
    private float currentHoverSpeed;
    [SerializeField]
    private float currentStrafeSpeed;


    [SerializeField]
    private float lookRateSpeed = 100f;
    [SerializeField]
    private float rollSpeed = 90f;
    [SerializeField]
    private float rollAcceleration = 3f;

    [SerializeField]
    private Vector2 lookInput;
    [SerializeField]
    private Vector2 screenCenter;
    [SerializeField]
    private Vector2 mouseDistance;
    [SerializeField]
    private float rollInput;
    [SerializeField]
    private bool foward;
    [SerializeField]
    private bool left;
    [SerializeField]
    private bool right;
    [SerializeField]
    private bool down;


    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        lookInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        mouseDistance = new Vector2((lookInput.x - screenCenter.x) / screenCenter.y, (lookInput.y - screenCenter.y) / screenCenter.y);
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime,
            rollInput * rollSpeed * Time.deltaTime, Space.Self);

        currentMovementSpeed = Mathf.Lerp(currentMovementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed, movementSpeedAcceleration * Time.deltaTime);
        currentHoverSpeed = Mathf.Lerp(currentHoverSpeed, Input.GetAxisRaw("Horizontal") * hoverSpeed, hoverSpeedAcceleration * Time.deltaTime);
        currentStrafeSpeed = Mathf.Lerp(currentStrafeSpeed, Input.GetAxisRaw("Hover") * strafeSpeed, strafeSpeedAcceleration * Time.deltaTime);

        transform.position += transform.forward * currentMovementSpeed * Time.deltaTime;
        transform.position += (transform.right * currentStrafeSpeed * Time.deltaTime) + (transform.up * currentHoverSpeed * Time.deltaTime);
    }
}
