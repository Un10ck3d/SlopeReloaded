using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_check : MonoBehaviour
{
    public GameObject cam;
    public generator spawn;
    private int z_cord;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        z_cord = ((int)cam.transform.position.z) - 30;
        if (transform.position.z < z_cord)
        {
            Destroy (gameObject);
            spawn.level_parts --;
        }
    }
}