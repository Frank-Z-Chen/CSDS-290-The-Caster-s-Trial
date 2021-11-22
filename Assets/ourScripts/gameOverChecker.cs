using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverChecker : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Ellen").GetComponent<Damageable>().currentHitPoints <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOver");
        }
    }
}
