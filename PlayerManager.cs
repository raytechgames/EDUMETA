using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    GameObject controller;
    // Start is called before the first frame update
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        if(PV.IsMine)
        {
            CreateController();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateController()
    {
        //instantiate player controller
        Transform spawnpoint = SpawnManager.instance.GetSpawnPoint();
      controller =   PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position, spawnpoint.rotation, 0, new object[] {PV.ViewID });
    }
    public void Die()
    {

        PhotonNetwork.Destroy(controller);
        CreateController();
    }
}
