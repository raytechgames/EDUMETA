using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotGun : Gun
{
    public Camera Cam;
    PhotonView PV;
    public string hittag;
    public AudioSource gunFire;
    private void Update()
    {
        
    }
    private void Awake()
    {
        PV = GetComponent<PhotonView>();    
    }
    public override void Use()
    {
        Shoot();
    }
    public void Shoot()
    {
        
        
       
    }
    [PunRPC]

    void RPC_Shoot(Vector3 hitPosition)
    {
        // instantiate bullet
        gunFire.Play();
        Instantiate(BulletImpactPrefab,hitPosition,Quaternion.identity);
       if(hittag=="Player")
        {
            Instantiate(BloodImpactPrefab, hitPosition, Quaternion.identity);

        }





    }
   
    



}
