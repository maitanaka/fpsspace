using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoomMatchMaker : Photon.MonoBehaviour {
	public GameObject photonObject;

	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom(){
		PhotonNetwork.Instantiate (
			photonObject.name,
			new Vector3 (233f, 5.5f, 179f),
			Quaternion.identity, 0
		);
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

}
