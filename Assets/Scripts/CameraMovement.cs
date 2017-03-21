using UnityEngine;

namespace Assets.Scripts
{
    public class CameraMovement : MonoBehaviour
    {

        private Vector3 movementVector;

        [SerializeField]
        private float speed = 0.3f;

        [SerializeField]
        private float sprintModifer = 3f;

        [SerializeField]
        [Tooltip("Mouse Sensitivity")]
        private float sensitivity = 0.5f;

        [SerializeField]
        private KeyCode sprintKey = KeyCode.LeftShift;

        private bool followMouseMovement = false;

        // Use this for initialization
        void Start()
        {
            movementVector = Vector3.zero;
        }

        // Update is called once per frame
        void Update()
        {
            GenerateMovementVector();
            //UPDATE POSITION
            transform.Translate((movementVector.normalized * speed * (Input.GetKey(sprintKey) ? sprintModifer : 1)) * Time.deltaTime, Space.Self);
            //MANAGE MOUSE HIDING/LOCKING
            if (Input.GetMouseButtonDown(1))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                followMouseMovement = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                followMouseMovement = false;
            }
            //SET ROTATION
            if (followMouseMovement)
            {
                Vector3 previousRot = transform.eulerAngles;
                Vector3 rotChange = new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0) * sensitivity;
                float xValue = rotChange.x + previousRot.x;

                transform.rotation = Quaternion.Euler(xValue, rotChange.y + previousRot.y, 0);
            }

        }

        void GenerateMovementVector()
        {
            movementVector = new Vector3(Input.GetAxisRaw("Sidewards"), Input.GetAxisRaw("Upwards"), Input.GetAxisRaw("Forwards"));
        }

    }
}
