using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float attackCounter;
    private float pickaxeCounter;
    public float attackCooldown = 2;
    public float pickaxeCooldown = 2;

    private bool coalLit = false;
    private bool swing = false;
    private bool lightcoal = false;

    // Start is called before the first frame update
    void PLight()
    {
        coalLit = true;
        Debug.Log("Light Coal");
    }

    void PSwing()
    {
        if (coalLit)
        {
            coalLit = false;
            Debug.Log("Throw Coal");
            attackCounter = attackCooldown;
        }
        else if (pickaxeCounter <= 0)
        {
            Debug.Log("Swing Pickaxe");
            pickaxeCounter = pickaxeCooldown;
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        swing = Input.GetButtonDown("Action1");
        lightcoal = Input.GetButtonDown("Action2");
        if (swing)
        {
            PSwing();
        }
        else
        {
            attackCounter -= Time.deltaTime;
        }

        if (lightcoal && !coalLit && attackCounter <= 0)
        {
            PLight();
        }
            pickaxeCounter -= Time.deltaTime;


    }
}
