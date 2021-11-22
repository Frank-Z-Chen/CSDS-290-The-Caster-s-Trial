using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizeKeyLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0, 3);
        Vector3[] positions = new Vector3[3];
        positions[0] = new Vector3(30, 0.671f, 15);
        positions[1] = new Vector3(53, 0.671f, 18);
        positions[2] = new Vector3(21, 0.671f, 2.4f);
        Vector3 chosenPosition = positions[x];
        transform.position = chosenPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
