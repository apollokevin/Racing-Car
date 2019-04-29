using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    private Vector3 pos = new Vector3();

    
    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, target.rotation.eulerAngles.y, 0);
    }
}
