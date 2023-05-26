/****
 * Author: Noman Saeed
 * Date: 25/05/2023
 * This scirpt is to handle messaging 
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
    public Transform m_chatHolder;//panel to display msgs
    public GameObject m_msgElement;//message prefab
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
        if(InstanceFinder.IsClient)
        InstanceFinder.ClientManager.UnregisterBroadcast<Message>(OnMessageRecieved);
        if(InstanceFinder.IsServer)
        InstanceFinder.ServerManager.UnregisterBroadcast<Message>(OnClientMessageRecieved);
    }
    public void SendChatMessage(string p_msg)
    {
        Message v_msg = new Message();

        v_msg.username = "user name";//TODO: fix it with generated name
        v_msg.message = "message to send";//TODO: fix it with avialble texts

        if (InstanceFinder.IsServer)
        {
            v_msg.message = p_msg; 
            InstanceFinder.ServerManager.Broadcast(v_msg);
            Debug.Log("server msg:" + p_msg);
        }
        else if (InstanceFinder.IsClient)
        {
            v_msg.message = p_msg;
            InstanceFinder.ClientManager.Broadcast(v_msg);
            Debug.Log("client msg:" + p_msg);
        }
    }
    private void OnMessageRecieved(Message p_msg)
    {
        GameObject v_finalMsg = Instantiate(m_msgElement, m_chatHolder);
        //TODO: concatinate the user name and msg 
        v_finalMsg.GetComponent<TextMeshProUGUI>().text += p_msg.username + ": " + p_msg.message; 
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
        //if() //TODO
        //{
        //    SendMessage();
        //}
    }
}
