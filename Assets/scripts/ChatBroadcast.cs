/****
 * Author: Noman Saeed
 * Date: 25/05/2023
 * This scirpt is to handel messaging 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FishNet;
using FishNet.Broadcast;
using FishNet.Connection;
using UnityEditor.VersionControl;

public class ChatBroadcast : MonoBehaviour
{
    public Transform m_chatHolder;
    public GameObject m_msgElement;
    public TMP_InputField m_pm,m_pu;

    public string m_playerUsername,m_playerMessage;
    
    public struct Message : IBroadcast
    {
        public string username;
        public string message;
    }
    //for reciving messages
    private void OnEnable()
    {
        InstanceFinder.ClientManager.RegisterBroadcast<Message>(OnMessageRecieved);
        InstanceFinder.ServerManager.RegisterBroadcast<Message>(OnClientMessageRecieved);
    }

    private void OnDisable()
    {
        InstanceFinder.ClientManager.UnregisterBroadcast<Message>(OnMessageRecieved);
        InstanceFinder.ServerManager.UnregisterBroadcast<Message>(OnClientMessageRecieved);
    }
    private void SendMessage()
    {
        Message v_msg = new Message();

        v_msg.username = "user name";//TODO: fix it with generated name
        v_msg.message = "message to send";//TODO: fix it with avialble texts

        if (InstanceFinder.IsServer)
        {
            InstanceFinder.ServerManager.Broadcast(v_msg);
        }
        else if (InstanceFinder.IsClient)
        {
            InstanceFinder.ClientManager.Broadcast(v_msg);
        }
    }
    private void OnMessageRecieved(Message p_msg)
    {
        GameObject v_finalMsg = Instantiate(m_msgElement, m_chatHolder);
        v_finalMsg.GetComponent<TextMeshProUGUI>().text = p_msg.username + ": " + p_msg.message; //TODO: concatinate the user name and msg 
    }

    private void OnClientMessageRecieved(NetworkConnection p_networkConnection, Message p_msg)
    {
        InstanceFinder.ServerManager.Broadcast(p_msg);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(true) //TODO
        {
            SendMessage();
        }
    }
}
