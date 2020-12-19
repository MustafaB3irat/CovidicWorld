using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeAndAttack : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collesionInfo)
    {
        if (collesionInfo.collider.tag == "Enemy")
        {
            triggerAnimation("isDied", true);
            FindObjectOfType<GameManager>().EndGame();
        }
    }


    void triggerAnimation(string animationTransitionParameter, bool trigger)
    {
        animator.SetBool(animationTransitionParameter, trigger);
    }
}
