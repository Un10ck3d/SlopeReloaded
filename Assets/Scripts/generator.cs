using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    // Jonathan edits:
    public GameObject startObject;
    public GameObject speedObject;

    //private GameObject[] predeterment;
    public GameObject[] predeterment;
    public GameObject[] basic;

    [HideInInspector]
    public int level_parts = 0;
    public int levels_at_a_time;
    private int last;
    private int last2;
    private float z_cord;
    private float y_cord;
    public float level_space;
    public float level_height;
    public GameObject clone_ref;
    private int speed = 1;
    private int nexo = 0;

    // Start is called before the first frame update
    void Start()
    {
        //predeterment.SetValue(startObject, 0);
        //predeterment.SetValue(speedObject, 1);
        new_level(0, 1, "pre");
    }

    // Update is called once per frame
    void Update()
    {
        if (level_parts < levels_at_a_time)
        {
            int fspeed;
            int ftspeed = 1;
            if (speed < 5)
            {
                fspeed = speed;
            }
            else
            {
                fspeed = 4;
            }
            if (speed < 4)
            {
                ftspeed = speed;
            }
            else
            {
                ftspeed = 3;
            }
            //print (ftspeed);
            //print (fspeed);
            int nn;
            do
            {
                nn = Random_range();
            } while ((nn == last) || (nn == last2));
            if (nexo < ftspeed)
            {
                new_level(nn, fspeed, "bas");
                nexo ++;
            }
            else
            {
                new_level(1, 1, "pre");
                speed ++;
                nexo = 0;
            }
            last2 = last;
            last = nn;
        }
    }
    void new_level(int index, int number_of_types_to_spawn, string type_of_array)
    {
        GameObject clone = null;
        if (number_of_types_to_spawn == 0)
        {
            number_of_types_to_spawn = 1;
        }
        for (int i = 1; i <= number_of_types_to_spawn; i++)
        {
            if (type_of_array == "bas")
            {
                clone = Instantiate(basic[index], new Vector3(0, y_cord, z_cord), Quaternion.identity);
            }
            else
            {
                clone = Instantiate(predeterment[index], new Vector3(0, y_cord, z_cord), Quaternion.identity);
            }
            if (clone != null)
            {
                clone.GetComponent<delete_check>().cam = clone_ref;
                clone.GetComponent<delete_check>().spawn = this;
            }
            z_cord = z_cord + 20 * level_space;
            y_cord = y_cord - level_height;
            level_parts ++;
        }
    }
    int Random_range()
    {
        int nextpr = Random.Range(0, basic.Length -1);
        return nextpr;
    }
}
