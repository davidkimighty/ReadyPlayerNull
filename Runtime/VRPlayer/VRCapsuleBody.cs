using UnityEngine;
using UnityEngine.InputSystem;

namespace CollieMollie.XR
{
    public class VRCapsuleBody : MonoBehaviour
    {
        #region Variable Field
        [Header("Follow Targets")]
        [SerializeField] private Transform _targetHead = null;
        [SerializeField] private float _chestOffsetFromHead = 0.1f;
        [SerializeField] private Transform _targetBody = null;
        [SerializeField] private Transform _targetFoot = null;

        [Header("Body Visuals")]
        [SerializeField] private Transform _capsuleBody = null;
        [SerializeField] private Transform _headPoint = null;
        [SerializeField] private Transform _chestPoint = null;
        [SerializeField] private Transform _footPoint = null;

        private Vector3 _initialScale = Vector3.zero;

        #endregion

        private void Awake()
        {
            _initialScale = _capsuleBody.localScale;
        }

        private void LateUpdate()
        {
            FollowTarget();
            ScaleCapsuleBodyByHeight();
        }

        #region Private Functions
        private void FollowTarget()
        {
            _headPoint.position = _targetHead.position;
            _headPoint.forward = _targetHead.forward;

            Vector3 chestPoint = _targetHead.position;
            chestPoint.y -= _chestOffsetFromHead;
            _chestPoint.position = chestPoint;
            _chestPoint.forward = _targetBody.forward;

            _footPoint.position = _targetFoot.position;
        }

        private void ScaleCapsuleBodyByHeight()
        {
            float dst = Vector3.Distance(_chestPoint.position, _footPoint.position);
            _capsuleBody.localScale = new Vector3(_initialScale.x, dst / 2f, _initialScale.z);

            Vector3 midPoint = (_chestPoint.position + _footPoint.position) / 2f;
            _capsuleBody.position = midPoint;

            Vector3 rotateDir = _footPoint.position - _chestPoint.position;
            _capsuleBody.up = rotateDir;
        }

        #endregion
    }
}
