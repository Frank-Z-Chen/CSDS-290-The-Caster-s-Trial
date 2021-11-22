using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leaveDungeon : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Leave") && GameObject.Find("Ellen").GetComponent<hasKey>().playerHasKey)
        {
            SceneManager.LoadScene("Escape Ending Scene");
        }
    }
}
