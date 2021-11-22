using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killall : MonoBehaviour
{

    public int enemiesDeadCounter = 0;

    public void increaseEnemiesDeadCounter()
    {
        enemiesDeadCounter += 1;
        if(enemiesDeadCounter == 10)
        {
            SceneManager.LoadScene("Kill All Ending Scene");
        }
    }
}
