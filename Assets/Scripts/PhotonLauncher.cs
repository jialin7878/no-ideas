using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine.UI;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private byte maxPlayersPerRoom = 2;

    public InputField roomID;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom()
    {
        string newRoomId = generateRandomRoomID();
        PhotonNetwork.CreateRoom(newRoomId, new RoomOptions { MaxPlayers = maxPlayersPerRoom }, null);
        Debug.Log("created new room with id " + newRoomId);
    }

    public void JoinRoom()
    {
        Debug.Log("Joining room with id " + roomID.text);
        PhotonNetwork.JoinRoom(roomID.text);
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master successfully");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("OnDisconnected() called with reason {0}", cause);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Join room " + roomID.text + " failed: " + message);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room successfully");
        PhotonNetwork.LoadLevel("Room");
    }

    private string generateRandomRoomID()
    {
        var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[5];
        var random = new System.Random();
        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        return new String(stringChars);
    }




}
