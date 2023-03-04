using UnityEngine;

namespace CollieMollie.XR
{
    public class ScaleFromTwoPivotPoint : MonoBehaviour
    {
        #region Variable Field
        [SerializeField] private Transform _target = null;
        [SerializeField] private Transform _pointOne = null;
        [SerializeField] private Transform _pointTwo = null;

        private Vector3 _initialScale = Vector3.zero;
        private float _previousSqrMagnitude = 0f;
        #endregion

        private void Awake()
        {
            _initialScale = _target.localScale;
        }

        private void LateUpdate()
        {
            PivotScale();
        }

        #region Private Functions
        private void PivotScale()
        {
            float sqrMag = (_pointOne.position - _pointTwo.position).sqrMagnitude;
            float dst = Vector3.Distance(_pointOne.position, _pointTwo.position);
            _target.localScale = new Vector3(_initialScale.x, dst / 2f, _initialScale.z);

            Vector3 midPoint = (_pointOne.position + _pointTwo.position) / 2f;
            _target.position = midPoint;

            Vector3 rotateDir = _pointTwo.position - _pointOne.position;
            _target.up = rotateDir;

            _previousSqrMagnitude = sqrMag;
        }

        #endregion
    }
}
