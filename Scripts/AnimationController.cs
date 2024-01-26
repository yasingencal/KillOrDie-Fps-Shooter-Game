using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //Animasyon Controller bile�enindeki de�i�kenlere ula��p animasyonlar� y�netmek i�in bir managment scripti
    public static AnimationController animationController;
    public Animator animator;
    void Awake()
    {
        animationController = this;
    }
    void Start()
    {
        
    }
    
    
    public void Reload()
    {
        animator.SetBool("isReload", true);
    }
    public void ReloadFinish()
    {
        animator.SetBool("isReload", false);
    }
}
