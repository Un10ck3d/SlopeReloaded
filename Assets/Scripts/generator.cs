using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    public GameObject[] prefabs;
    public int level_parts;
    public int levels_at_a_time;
    private int last;
    private int last2;
    public float z_cord;
    public float y_cord;
    public float level_space;
    public GameObject clone_ref;
    // Start is called before the first frame update
    void Start()
    {
        new_level(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (level_parts < levels_at_a_time)
        {
            int nn;
            do
            {
                nn = Random_range();
            } while ((nn == last) || (nn == last2));
            z_cord = z_cord + (20 * level_space);
            y_cord = y_cord -5;
            new_level(nn);
            level_parts ++;
            last2 = last;
            last = nn;
        }
    }
    void new_level(int x)
    {
        var clone = Instantiate(prefabs[x], new Vector3(0, y_cord, z_cord), Quaternion.identity);
        clone.GetComponent<delete_check>().cam = clone_ref;
        clone.GetComponent<delete_check>().spawn = this;
    }
    int Random_range()
    {
        int nextpr = Random.Range(1, prefabs.Length);
        return nextpr;
    }
}