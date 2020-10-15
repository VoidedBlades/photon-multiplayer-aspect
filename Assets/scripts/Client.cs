using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviourPunCallbacks
{

    [SerializeField] private Text LocalUsername;

    public void ConnectClient()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.NickName = "Player #" + Random.Range(0, 1000);

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinOrCreateRoom("Testing", new Photon.Realtime.RoomOptions() { MaxPlayers = 2 }, null);
     }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("added");

        Vector3 m_Position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));

        GameObject Me = PhotonNetwork.Instantiate("Player", m_Position, Quaternion.identity, 0, new object[1] { 1 });
        Me.transform.Find("Canvas").Find("Username").GetComponent<Text>().text = "You";
        LocalUsername.text = PhotonNetwork.NickName;
    }

    private void Start()
    {
        ConnectClient();
    }
}
