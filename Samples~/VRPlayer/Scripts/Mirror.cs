using UnityEngine;

public class Mirror : MonoBehaviour
{
    #region Variable Field
    [SerializeField] private Transform _player = null;
    [SerializeField] private Transform _mirror = null;

    #endregion

    private void Update()
    {
        Vector3 playerLocal = _mirror.InverseTransformPoint(_player.position);
        transform.position = _mirror.TransformPoint(new Vector3(playerLocal.x, playerLocal.y, -playerLocal.z));

        Vector3 lookMirrorPoint = _mirror.TransformPoint(new Vector3(-playerLocal.x, playerLocal.y, playerLocal.z));
        transform.LookAt(lookMirrorPoint);
    }
}