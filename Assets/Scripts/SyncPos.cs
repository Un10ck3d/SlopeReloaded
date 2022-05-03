using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syncPos : MonoBehaviour
{
    public GameObject syncPosObject;
    void FixedUpdate(){transform.position = syncPosObject.transform.position;}
}
