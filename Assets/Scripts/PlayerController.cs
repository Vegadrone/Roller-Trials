using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    [Header ("Debugging")]
    [SerializeField] Debugger logger;
    [Header("Movement Values")]
    [SerializeField] float torqueAmount = 0f;
    [SerializeField] float forceMagnitude = 1f;
    [SerializeField] float airResistance = 0.5f;
    Rigidbody2D playerRb;
    CapsuleCollider2D rollerBladesCollider;
    LayerMask ground;
    Vector2 torqueInput;
    bool isAccelerationPressed;
    bool canMove = true;
    public static Vector3  playerPos;



    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        rollerBladesCollider = GetComponentInChildren<CapsuleCollider2D>();
        ground = LayerMask.GetMask("Ground");
        Debugger.DebuggerLoader(ref logger);
    }

   void FixedUpdate() 
    {   
        playerPos = this.transform.position;
        if (canMove)
        {
            AddingTorque(); 
            Accelerate();
        }
        //logger.Log("Questa è la posizione del Player" + " " + playerPos, this);
    }

    void OnTorque(InputValue value)
    {   
        torqueInput = value.Get<Vector2>();
    }

    void OnAccelerate(InputValue value)
    {
        if (value.isPressed)
        {
            isAccelerationPressed = true;
            logger.Log("Il tasto è stato premuto",this);
            
        }
        else if(!value.isPressed)
        {
            isAccelerationPressed = false;
            logger.Log("Il tasto è stato rilasciato", this);
        }
    }

    void AddingTorque()
    {
        if (torqueInput.x > 0)
        {
            playerRb.AddTorque(-torqueAmount * Time.fixedDeltaTime);
            logger.Log("Ruota a dx", this);
        }
        else if (torqueInput.x < 0)
        {
            playerRb.AddTorque(torqueAmount * Time.fixedDeltaTime);
            logger.Log("Ruota a sx", this);
        }
    }

    void Accelerate()
    {
        if (rollerBladesCollider.IsTouchingLayers(ground))
        {
            if (isAccelerationPressed)
            {
                playerRb.AddForce(Vector2.right * forceMagnitude * Time.fixedDeltaTime, ForceMode2D.Force);
            }
            else
            {   
                //Questa formula crea l'inerzia desiderata mettendo una forza opposta al vettore sull'asse x
                Vector2 resistanceForce = new Vector2(-playerRb.velocity.x * airResistance * Time.fixedDeltaTime, 0f);
                playerRb.AddForce(resistanceForce, ForceMode2D.Force);
            }
        }
    }

    public void DisableControls()
    {
        canMove = false;
        logger.Log("CONTROLLI DISABILITATI", this);
    }
}