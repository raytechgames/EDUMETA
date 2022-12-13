using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public TMP_InputField RoomNameInput; //field to input 
    public Text errorText,RoomNameText;  // errorDisplay,RoomNameDisplay
   public Transform roomListContent,PlayerListContent;
  public  GameObject roomListPrefab ,PlayerListPrefab;
    public static Launcher Instance;
    public GameObject startGameButton;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("lobby");
        

        
        Debug.Log("Joined Lobby");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(RoomNameInput.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(RoomNameInput.text);
        MenuManager.Instance.OpenMenu("loading");
    }
    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("RoomMenu");
        RoomNameText.text = PhotonNetwork.CurrentRoom.Name;
        Player[] players = PhotonNetwork.PlayerList;
        foreach(Transform child in PlayerListContent )
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(PlayerListPrefab, PlayerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);

        }
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);


    }
    // if master leaves the room we need to asign new host
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failed" + message;
        MenuManager.Instance.OpenMenu("ErrorMenu");
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }
    public void OnleftRoom()
    {
        MenuManager.Instance.OpenMenu("lobby");
    }
    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("loading");
        
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }
        for(int i = 0; i< roomList.Count;i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(roomListPrefab,roomListContent).GetComponent<RoomlistItem>().SetUp(roomList[i]);

        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(PlayerListPrefab, PlayerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }
    public void StartGame()
    {
        
        PhotonNetwork.LoadLevel(1);
    }

}

