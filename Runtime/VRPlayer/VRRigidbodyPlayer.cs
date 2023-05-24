using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace CollieMollie.XR
{
    public class VRRigidbodyPlayer : MonoBehaviour
    {
        #region Variable Field
        [SerializeField] private XROrigin _xrOrigin = null;
        [SerializeField] private float _chestOffsetFromHead = 0.1f;
        [SerializeField] private CapsuleCollider _bodyCollider = null;
        [SerializeField] private SphereCollider _rollerCollider = null;
        [SerializeField] private float _bodyHeightMin = 0.3f;
        [SerializeField] private float _bodyHeightMax = 2f;
        [SerializeField] private float _bodyFromGround = 0.15f;


        [SerializeField] private GameObject head = null;
        [SerializeField] private GameObject body = null;
        [SerializeField] private Rigidbody roller = null;

        [SerializeField] private float _rollerForce = 30f;
        [SerializeField] private float _angularDrag = 10f;


        [SerializeField] private InputActionProperty _rightHandMoveAction;
        private Vector2 _moveInput = Vector2.zero;

        #endregion

        private void Awake()
        {
            Physics.IgnoreCollision(_bodyCollider, _rollerCollider);
        }

        private void Update()
        {
            _moveInput = _rightHandMoveAction.action.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            UpdateBodyCollider();
            SpinRoller();
        }

        #region Private Functions
        private void UpdateBodyCollider()
        {
            float heightTillChest = _xrOrigin.Camera.transform.position.y - (_chestOffsetFromHead + _bodyFromGround);
            _bodyCollider.height = Mathf.Clamp(heightTillChest, _bodyHeightMin, _bodyHeightMax);
            float colliderCenterY = (_bodyCollider.height / 2) + _bodyFromGround;
            _bodyCollider.center = new Vector3(_bodyCollider.center.x, colliderCenterY, _bodyCollider.center.z);
        }


        private void SpinRoller()
        {
            Vector3 moveDir = new Vector3(_moveInput.y, 0, -_moveInput.x);
            Debug.Log(moveDir);

            if (roller.freezeRotation)
                roller.freezeRotation = false;

            roller.angularDrag = _angularDrag;
            roller.AddTorque(moveDir.normalized * _rollerForce, ForceMode.Force);
        }


        #endregion
    }
}
