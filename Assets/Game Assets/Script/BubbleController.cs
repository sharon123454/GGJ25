using UnityEngine.InputSystem;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.2f;
    [SerializeField] private float xclamp = 3.8f;
    [SerializeField] private float zclamp = 2.5f;

    private Rigidbody rigidBody;
    private Vector2 v2MoveDirection;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        v2MoveDirection = context.ReadValue<Vector2>();
    }

    private void HandleMovement()
    {
        Vector3 currentPo = rigidBody.position;
        Vector3 moveDir = new Vector3(v2MoveDirection.x, 0, v2MoveDirection.y);
        Vector3 nextPos = currentPo + moveDir * (moveSpeed * Time.fixedDeltaTime);

        nextPos.x = Mathf.Clamp(nextPos.x, -xclamp, xclamp);
        nextPos.z = Mathf.Clamp(nextPos.z, -zclamp, zclamp);

        rigidBody.MovePosition(nextPos);
    }

}