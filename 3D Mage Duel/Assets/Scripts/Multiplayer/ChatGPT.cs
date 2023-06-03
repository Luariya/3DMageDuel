using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatGPT : MonoBehaviour
{


public class MultiplayerGame : MonoBehaviourPun // IPunObservable
{
    // Player data structure to hold position, health, and input
    [System.Serializable]
    public struct PlayerData
    {
        public Vector3 position;
        public int health;
        public float horizontalInput;
        public float verticalInput;
        public bool spaceKeyDown;
        public bool leftMouseButtonDown;
    }

    public static MultiplayerGame Instance;

    // Dictionary to store player data by player ID
    private Dictionary<int, PlayerData> playerDataDictionary = new Dictionary<int, PlayerData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            // Update the local player's input and send it over the network
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            bool spaceKeyDown = Input.GetKeyDown(KeyCode.Space);
            bool leftMouseButtonDown = Input.GetMouseButtonDown(0);

            SendPlayerInput(horizontalInput, verticalInput, spaceKeyDown, leftMouseButtonDown);
        }
        else
        {
            // Update the game state based on the received player data
            UpdateGameState();
        }
    }

    private void SendPlayerInput(float horizontalInput, float verticalInput, bool spaceKeyDown, bool leftMouseButtonDown)
    {
        PlayerData playerData;
        playerData.position = transform.position;
      //  playerData.health = GetHealth();
        playerData.horizontalInput = horizontalInput;
        playerData.verticalInput = verticalInput;
        playerData.spaceKeyDown = spaceKeyDown;
        playerData.leftMouseButtonDown = leftMouseButtonDown;

      //  photonView.RPC("ReceivePlayerInput", RpcTarget.Others, playerData);
    }

    [PunRPC]
    private void ReceivePlayerInput(PlayerData playerData, PhotonMessageInfo info)
    {
        UpdatePlayerData(info.Sender, playerData);
    }

    public void UpdatePlayerData(Player player, PlayerData data)
    {
        int actorNumber = player.ActorNumber;

        if (playerDataDictionary.ContainsKey(actorNumber))
        {
            // Update existing player data
            playerDataDictionary[actorNumber] = data;
        }
        else
        {
            // Add new player data
            playerDataDictionary.Add(actorNumber, data);
        }
    }

    private void UpdateGameState()
    {
        // Iterate through the player data dictionary and update the game state accordingly
        foreach (var entry in playerDataDictionary)
        {
            int actorNumber = entry.Key;
            PlayerData data = entry.Value;

            // Get the player GameObject based on the actor number
            Player player = PhotonNetwork.CurrentRoom.GetPlayer(actorNumber);
            GameObject playerObject = player.TagObject as GameObject;

            // Update the player's position
            playerObject.transform.position = data.position;

            // Update the player's health
            // Replace this with your own health system logic
        //    HealthSystem healthSystem = playerObject.GetComponent<HealthSystem>();
        //    if (healthSystem != null)
            {
         //       healthSystem.SetHealth(data.health);
            }

            // Update the player's input
         //   PlayerInput playerInput = playerObject.GetComponent<PlayerInput>();
        //    if (playerInput != null)
            {
        //        playerInput.SetInput(data.horizontalInput, data.verticalInput, data.spaceKeyDown, data.leftMouseButtonDown);
            }
        }
    }
}
}
