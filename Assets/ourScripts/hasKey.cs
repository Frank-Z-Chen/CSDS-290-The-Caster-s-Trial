using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasKey : MonoBehaviour
{

    public bool playerHasKey = false;

    public void gotKey()
    {
        playerHasKey = true;
    }
}
