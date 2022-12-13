using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class UserNameDisplay : MonoBehaviour
{
    public PhotonView playerPV;
    public Text usernameText;
    public GameObject usernametext;
    private void Start()
    {
        if(playerPV.IsMine)
        {
            usernametext.SetActive(false);
        }
        usernameText.text = playerPV.Owner.NickName;
    }

}
