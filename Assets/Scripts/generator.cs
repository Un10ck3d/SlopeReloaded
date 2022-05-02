using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    public GameObject[] predeterment;
    public GameObject[] basic;
    public int level_parts = 0;
    public int levels_at_a_time;
    private int last;
    private int last2;
    public int z_cord;
    public int y_cord;
    public float level_space;
    public GameObject clone_ref;
    public int speed;
    public int nexo = 0;
    // Start is called before the first frame update
    void Start()
    {
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
            print ("ft");
            print (ftspeed);
            print ("f");
            print (fspeed);
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
                Debug.Log("bas");
            }
            else
            {
                clone = Instantiate(predeterment[index], new Vector3(0, y_cord, z_cord), Quaternion.identity);
                Debug.Log("pre");
            }
            if (clone != null)
            {
                clone.GetComponent<delete_check>().cam = clone_ref;
                clone.GetComponent<delete_check>().spawn = this;
            }
            z_cord = (Mathf.RoundToInt(z_cord + 20 * level_space));
            y_cord = y_cord -8;
            level_parts ++;
        }
    }
    int Random_range()
    {
        int nextpr = Random.Range(1, basic.Length);
        return nextpr;
    }
}
