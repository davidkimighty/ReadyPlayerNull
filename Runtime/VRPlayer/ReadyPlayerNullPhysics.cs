using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CollieMollie.XR
{
    public class ReadyPlayerNullPhysics : MonoBehaviour
    {
        #region Variable Field
        [SerializeField] private XROrigin _xrOrigin = null;
        [SerializeField] private SphereCollider _headCollider = null;
        [SerializeField] private CapsuleCollider _bodyCollider = null;
        [SerializeField] private SphereCollider _rollerCollider = null;
        [SerializeField] private float _chestOffsetFromHead = 0.1f;
        [SerializeField] private float _bodyHeightMin = 0.3f;
        [SerializeField] private float _bodyHeightMax = 2f;
        [SerializeField] private float _bodyFromGround = 0.15f;

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
            UpdateColliders();
            SpinRoller();
        }

        #region Private Functions
        private void UpdateColliders()
        {
            _headCollider.center = _xrOrigin.Camera.transform.position;

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
