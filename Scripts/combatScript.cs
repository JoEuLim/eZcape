using UnityEngine;

public class combatScript : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxCombodelay = 1f;

    void Start()
    { 
    anim = GetComponent<Animator>();
    
    }
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("axeAttack1"))
        {
            anim.SetBool("axeAttack1", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("axeAttack2"))
        {
            anim.SetBool("axeAttack2", false);
            noOfClicks = 0;
        }

        if (Time.time - lastClickedTime > maxCombodelay)
        { noOfClicks = 0; }
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            { 
                
                OnClick(); 
            
            
            }


        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 2);
        if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("axeAttack1"))
        {
            anim.SetBool("axeAttack1", false);
            anim.SetBool("axeAttack2", true);
        }
    }
    void OnClick()
    { 
    lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1) 
        {
            anim.SetBool("axeAttack1", true);
        }
       
    
    }
}
