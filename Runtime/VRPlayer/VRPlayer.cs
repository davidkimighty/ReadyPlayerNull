using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace CollieMollie.XR.Player
{
    public class VRPlayer : MonoBehaviour
    {
        #region Variable Field
        [Header("Locomotion Providers")]
        [SerializeField] private ActionBasedContinuousMoveProvider _continuousMoveProvider = null;
        [SerializeField] private ActionBasedSnapTurnProvider _snapTurnProvider = null;
        [SerializeField] private ActionBasedContinuousTurnProvider _continuousTurnProvider = null;
        [SerializeField] private TeleportationProvider _teleportationProvider = null;

        #endregion
    }
}
