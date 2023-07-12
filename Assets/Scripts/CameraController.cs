using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CameraMode cameraMode = CameraMode.QuaterView;
    [SerializeField] Vector3 delta = new Vector3(0, 5, -5); // 카메라와 타겟 간의 거리
    [SerializeField] GameObject player;

    void Start()
    {
        
    }

  
    void LateUpdate()
    {
        if(cameraMode == CameraMode.QuaterView)
        {
            RaycastHit hit;
            if(Physics.Raycast(player.transform.position, delta, out hit, delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point-player.transform.position).magnitude*0.8f;
                transform.position = player.transform.position + delta.normalized*dist;
            }
            else
            {
                transform.position = player.transform.position + delta;
                transform.LookAt(player.transform);
            }
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        cameraMode = CameraMode.QuaterView;
        this.delta= delta;
    }
}
