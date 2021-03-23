using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform cameraOffset;
    [SerializeField] Transform player;
    Vector3 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = transform.position;
        transform.rotation = cameraOffset.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(cameraPos.x , cameraPos.y , player.position.z);
    }
}
