using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Userdata : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
    public void OnPhotonInstantiate(PhotonMessageInfo _info)
    {
        if (_info.Sender != PhotonNetwork.LocalPlayer)
            _info.photonView.gameObject.transform.Find("Canvas").Find("Username").GetComponent<Text>().text = _info.Sender.NickName;
    }
}
