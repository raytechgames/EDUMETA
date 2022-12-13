using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviourPunCallbacks, IDamagable
{
    public GameObject cameraHolder;
    public float MouseSensitivity, 
        SprintSpeed, 
        walkspeed, 
        jumpforce, 
        smoothTime;
    float verticalLookRotation;
    Vector3 SmoothMoveVelocity;
    Vector3 moveAmount;

   public bool grouded;
    PhotonView pv;
    Rigidbody rb;
    public static PlayerController instance;

    public Item[] items;
    int itemindex;
    int previousItemIndex = -1;
    const float maxHealth = 100f;
    float currenthealth = maxHealth;
    PlayerManager playerManager;
    public Slider playerSlider, globalSlider;
    public GameObject playerslider, globalslider,pistol,rifle;
    //mobile code
    public Vector2 LookAxis;
    public float lookSpeed = 1.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;
    public GameObject playerCamera;
    public InputField ChatInputfield;
    public Text chaboxText;
    //equip a weapon on the player
    void EquipItem(int index)
    {
        if(index==previousItemIndex)
        
            return;
        



        itemindex = index;
        items[index].itemGameObject.SetActive(true);

        if(previousItemIndex!=-1)
        {
            items[previousItemIndex].itemGameObject.SetActive(false);
        }
        previousItemIndex = index;

        //ensure its the local player 
        if(pv.IsMine)
        {
            //item index over network
            Hashtable hash = new Hashtable();
            hash.Add("itemIndex",itemindex);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);

        }
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        //all players will be in sync with the local player
       if(!pv.IsMine && targetPlayer==pv.Owner)
        {
            EquipItem((int)changedProps["itemIndex"]);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        pv = GetComponent<PhotonView>();    
        instance = this;
        playerManager = PhotonView.Find((int)pv.InstantiationData[0]).GetComponent<PlayerManager>();
    }

    public int weapon = 0;
    public void SelectWeapon1()
    {
        weapon = 1;
        
    }
    public void SelectWeapon2()
    {
        weapon = 2;

    }
    
    private void Update()
    {
        //[prevents players from controlloing other players
        if (!pv.IsMine)
            return;
        look();
        move();
        Chat();
       // lookMobile();
       


        // jump();
        /*
        for (int i = 0; i < items.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                
                EquipItem(i);
                break;
            }
        }*/

        for (int i = 0; i < items.Length; i++)
        {
            if (weapon == 1)
            {

                EquipItem(i+1);
                break;
            }
            if(weapon==2)
            {
                EquipItem(i);
                break;
            }
            
        }
        



        //switch between weapons

        if (Input.GetAxisRaw("Mouse ScrollWheel")>0)
        {
            if (itemindex >= items.Length - 1)
            {
                EquipItem(0);
            }
            EquipItem(itemindex+1);
        }
       else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            if(itemindex<=0)
            {
                EquipItem(items.Length - 1);
            }
            else
            {
                EquipItem(itemindex - 1);
            }
            
        }

        // for android disable
       
        if(Input.GetButton("Fire1"))
        {
            
          // items[itemindex].Use();

        }
       
        if(transform.position.y< -10f)
        {
            Die(); //if you fall out of the world
        }
    }
    private void Start()
    {
        if(pv.IsMine)
        {
           EquipItem(0);
            Destroy(globalslider);
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
            Destroy(playerslider);
            
            
        }
    }
    private void FixedUpdate()
    {
        //set at an interval 0.02 seconds
        if (!pv.IsMine)
            return;
        
        rb.MovePosition(rb.position +transform.TransformDirection(moveAmount)* Time.deltaTime);
    }
    // looks physics of the player

    
   public void look()
    {
        transform.Rotate(Vector3.up * SimpleInput.GetAxisRaw("Mouse X") * MouseSensitivity);

        verticalLookRotation += SimpleInput.GetAxisRaw("Mouse Y") * MouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    public void lookMobile()
    {
        rotationX += -LookAxis.y * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, LookAxis.x * lookSpeed, 0);
    }
    //player movement
    void move()
    {
        Vector3 moveDir = new Vector3(SimpleInput.GetAxisRaw("Horizontal"), 0, SimpleInput.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir *(Input.GetKey(KeyCode.LeftShift)? SprintSpeed : walkspeed), ref SmoothMoveVelocity, smoothTime);

    }
    //  jump mechanics (using a different code for jump)
    void jump()
    {
        if(Input.GetKey(KeyCode.Space) && grouded)
        {
            rb.AddForce(transform.up * jumpforce);

        }
    } 
    public void SetGroundState(bool _grounded)
    {

        grouded = _grounded;

    }
    public void TakeDamage(float damage)
    {
        pv.RPC("RPC_TakeDamage",RpcTarget.All,damage);
    }
    [PunRPC]
    public void Chat()
    {
        ChatInputfield.text = chaboxText.text;
    }
    void RPC_TakeDamage(float damage)
    {
        //health

        if (pv.IsMine)
            
        Debug.Log("Took damage " + damage);
        currenthealth -= damage;
        globalSlider.value = currenthealth / maxHealth;

        if (!pv.IsMine)
            return;
        Debug.Log("Took damage " + damage);
        currenthealth -= damage;
        playerSlider.value = currenthealth / maxHealth;
        

        if (currenthealth<=0)
        {
            Die();
        }


    }
  public void Die()
    {
       playerManager.Die();
    }
    public void AndroidShoot()
    {
        items[itemindex].Use();
    }
   

    



}
