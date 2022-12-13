using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;
public class RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public static RoomManager instance;

    private void Awake()
    {
        if (instance)  //checks if another room mamanger is on scene 
        {
            Destroy(gameObject);  //only one room manager 
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public override void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  // enable the scene
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 1) // in game scene
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);

            // instantiate player prefab
        }
    }
    public override void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


}
