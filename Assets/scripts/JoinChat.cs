using FishNet.Broadcast;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JoinChat : MonoBehaviour
{
    public TMP_InputField m_userNameInputField;
    public TMP_Text m_textInvalidUser;
    public GameObject m_msgElement;//message prefab
    private bool m_connectOrNot = false;
    public void JoinServer(bool p_connect)
    {

    }
    public struct Message : IBroadcast
    {
        public string username;
        public string message;
    }
    // Start is called before the first frame update
    public void onJoinBtn()
    {
        string v_strName;//= new string();
        v_strName = m_userNameInputField.text;//GetComponent<TextMeshProUGUI>().text.ToString();
        if (v_strName != null)
        {
            //TODO: make the message object and load the chat room scene
            //user name is same as user typed (can add random number with it)
            //message 
            m_textInvalidUser.text = m_userNameInputField.text;
        }
        //potentially can add other tests for checking valid user name i.e., special char's , longer than a certain size
        if(v_strName.Length <=0) {
            Debug.Log("Name Length is not valid");
            m_textInvalidUser.text = "Name is not of valid length";
        }
    }
    void Start()
    {
        //m_userNameInputField.onValueChanged.AddListener(onJoinBtn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
