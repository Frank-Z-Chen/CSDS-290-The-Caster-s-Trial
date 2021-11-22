using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dazeEnemies : MonoBehaviour
{


    List<Animator> animatorList = new List<Animator>();
    Animator ellenAnim;

    // Start is called before the first frame update
    void Start()
    {
        ellenAnim = GetComponent<Animator>();
        animatorList.Add(GameObject.Find("DireWolfRetarget").GetComponent<Animator>());
        for(int i = 1; i < 10; i++)
        {
            animatorList.Add(GameObject.Find("DireWolfRetarget (" + i +")").GetComponent<Animator>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Daze") && !ellenAnim.GetCurrentAnimatorStateInfo(0).IsName("Standing 2H Cast Spell 01"))
        {
            ellenAnim.SetBool("Daze", true);
            foreach (Animator animator in animatorList)
            {
                if(animator != null)
                {
                    animator.SetBool("Daze", true);
                }
            }
        }
    }
}
