/****
 * Author: Noman Saeed
 * Date: 25/05/2023
 * Purpose of this  script is to check the valid Input of Chat ID and to join the chat room.
 */
using FishNet.Broadcast;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class JoinChat : MonoBehaviour
{
    public TMP_InputField m_userNameInputField;
    public TMP_Text m_textInvalidUser;//if the user name is invalid show msg here        
    public static string m_userName;
    
    
    //check if input is valid then load the chat room scene
    public void onJoinBtn()
    {
        string v_strName;
        v_strName = m_userNameInputField.text;
        if (v_strName != null)
        {           
            m_textInvalidUser.text = m_userNameInputField.text;
            m_userName = m_userNameInputField.text; //for passing the username to the chat room scene
            SceneManager.LoadScene("scn_chatroom");            
        }
        //can add other tests for checking valid user name i.e., special char's , longer than a certain size
        if(v_strName.Length <=0) {
            //Debug.Log("Name Length is not valid");
            m_textInvalidUser.text = "Name is not of valid length";
        }
    }

}
