using UnityEngine;
using Cinemachine;

public class CinemachineCameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera PlayerFollowCamera;
    public CinemachineVirtualCamera TopDownCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            PlayerFollowCamera.Priority = 28;
            TopDownCamera.Priority = 29;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            TopDownCamera.Priority = 28;
            PlayerFollowCamera.Priority = 29;
        }
    }
}
