using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float smooth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var target = player.position;
        target.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, target, smooth);
    }
}
