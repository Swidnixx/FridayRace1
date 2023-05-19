using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Vector3[] positions;
    public CinemachineVirtualCamera vcamera;
    CinemachineTransposer transposer;
    int currentPosition = 0;

    private void Start()
    {
        transposer = vcamera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = positions[0];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            currentPosition++;
            currentPosition = currentPosition % positions.Length;

            transposer.m_FollowOffset = positions[currentPosition];
        }
    }

    public void SetCameraToCar(Transform car)
    {
        vcamera.Follow = car;
        vcamera.LookAt = car;
    }
}
