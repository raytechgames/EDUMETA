using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
public class PlayerListItem : MonoBehaviourPunCallbacks
{
    Player player;
   public Text text;
   public void SetUp(Player _player)
    {
        player = _player;
        text.text = _player.NickName;


    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(player==otherPlayer)
        {
            Destroy(gameObject);
        }
    }
    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
