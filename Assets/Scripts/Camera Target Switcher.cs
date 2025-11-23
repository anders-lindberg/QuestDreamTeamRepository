using UnityEngine;
using Unity.Cinemachine;
public class CameraTargetSwitcher : MonoBehaviour
{
    public CinemachineCamera virtualCamera;
    Transform newTarget;

    void Start()
    {
        newTarget = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        if (newTarget == null)
        {
            newTarget = GameObject.FindWithTag("PlayerPickaxe").transform;
            SetNewTarget();
        }
    }

    // Example: call this to change the camera target
    public void SetNewTarget()
    {
        virtualCamera.Follow = newTarget;
    }
}
