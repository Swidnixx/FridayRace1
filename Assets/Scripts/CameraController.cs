using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Vector3[] positions;
    public CinemachineVirtualCamera camera;
    CinemachineTransposer transposer;

    private void Start()
    {
        transposer = camera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = positions[0];
    }
}
