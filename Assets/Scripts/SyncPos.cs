using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPos : MonoBehaviour
{
    public GameObject syncPosObject;
    void FixedUpdate(){transform.position = syncPosObject.transform.position;}
}
