using System;
using UnityEngine;

namespace CollieMollie.XR
{
    [CreateAssetMenu(fileName = "EventChannel_VRPlayer", menuName = "CollieMollie/Event Channels/VR Player")]
    public class VRPlayerEventChannel : ScriptableObject
    {
        #region Events
        public event Action<Vector3> OnNeckPositionChange = null;

        #endregion

        #region Publishers


        #endregion
    }
}
