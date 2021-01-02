using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public Text roomIdText;

    private void Start()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("missing player prefab!");
        } 
        else
        {
            Debug.Log("Instantiating player");
            PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
            getCurrentRoomId();
        }
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }


    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("Left room");
    }


    private void getCurrentRoomId()
    {
        roomIdText.text = PhotonNetwork.CurrentRoom.Name;
    }

}
