using UnityEngine;

namespace CollieMollie.XR
{
    public class VRPhysicsPlayer : MonoBehaviour
    {
        #region Variable Field
        [SerializeField] private Transform _playerHead = null;
        [SerializeField] private CapsuleCollider _bodyCollider = null;
        [SerializeField] private float _bodyHeightMin = 0.3f;
        [SerializeField] private float _bodyHeightMax = 2f;
        [SerializeField] private float _bodyFromGround = 0.15f;

        [SerializeField] private SphereCollider _rollerCollider = null;
        [SerializeField] private ConfigurableJoint _bodyToRollerJoint = null;

        #endregion

        private void Awake()
        {
            Physics.IgnoreCollision(_bodyCollider, _rollerCollider);
        }

        private void FixedUpdate()
        {
            _bodyCollider.height = Mathf.Clamp(_playerHead.position.y, _bodyHeightMin, _bodyHeightMax);
            _bodyCollider.center = new Vector3(_playerHead.localPosition.x, (_bodyCollider.height / 2) + _bodyFromGround, _playerHead.localPosition.z);
            _bodyToRollerJoint.anchor = new Vector3(_playerHead.localPosition.x, _bodyToRollerJoint.anchor.y, _playerHead.localPosition.z);
        }
    }
}
