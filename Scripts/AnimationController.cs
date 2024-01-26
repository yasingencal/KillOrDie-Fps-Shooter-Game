using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //Animasyon Controller bileþenindeki deðiþkenlere ulaþýp animasyonlarý yönetmek için bir managment scripti
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
