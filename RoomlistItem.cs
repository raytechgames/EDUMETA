using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoomlistItem : MonoBehaviour
{
    public Text text;
  public  RoomInfo info;
   public void SetUp(RoomInfo _info)
   {
        info = _info;
        text.text = info.Name;
   }
    public void OnClick()
    {
       Launcher.Instance.JoinRoom(info);
    }
}
