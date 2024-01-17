using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using System.Text.RegularExpressions;

public class RegisterMenu : MonoBehaviour
{
    EventSystem system;

    [SerializeField] public Button submitbutton;
    [SerializeField] public TextMeshProUGUI[] message;
    [SerializeField] public InputField Password;
    [SerializeField] public InputField RePassword;
    [SerializeField] public InputField UserName;
    
    void Start()
    {
        system = EventSystem.current;
        ////submitbutton.onClick.AddListener(AnalyzeInput);
        UserName.onEndEdit.AddListener((s) => CheckUserName());
        Password.onEndEdit.AddListener((s) => CheckPassword());
        RePassword.onEndEdit.AddListener((s)=> CheckRePassword());
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (previous != null) { previous.Select(); }
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null) { next.Select(); }
        }
    }

    private bool CheckUserName()
    {
        string username = UserName.text;
        message[0].color = Color.red;
        if (username.Length < 8 ) 
        {
            message[0].text = "UserName Must Be More Then 8 Character!"; return false;
        }
        if (username.Length > 30)
        {
            message[0].text = "UserName Must Be Less Then 30 Character!"; return false;
        }
        message[0].color = Color.green;
        message[0].text = "OK";
        return true;
    }
    private bool CheckPassword()
    {
        string password = Password.text;
        message[1].color = Color.red;
        if (password.Length < 8)
        {
            message[1].text = "Password Must Longer Then 8 Character!"; return false;
        }
        if (!Regex.IsMatch(password,"[a-z]"))
        { message[1].text = "Password must has at least one lower letter";return false; };
        if (!Regex.IsMatch(password, "[0-9]"))
        { message[1].text = "Password must has at least one digit";return false; }
        if (!Regex.IsMatch(password, "[A-Z]"))
        { message[1].text = "Password must has at least one upper letter"; return false; }
        if (!Regex.IsMatch(password, "[!@#$%^&*]"))
        { message[1].text = "Password must has at least one special charactor"; return false; }
        message[1].color = Color.green;
        message[1].text = "OK";
        return true;
        
    }
    private bool CheckRePassword()
    {
        string password = Password.text;
        string repassword = RePassword.text;
        message[2].color = Color.red;
        if (!password.Equals(repassword)) { message[2].text = "Incorrect With Password!!!"; return false; }
        message[2].color = Color.green;
        message[2].text = "OK";
        return true;
    }
    ////private void AnalyzeInput()
    ////{
    ////    bool isAccessGranted = CheckUserName() && CheckPassword() && CheckRePassword();
    ////    if (!isAccessGranted )
    ////    {
    ////        Debug.Log("Failure register");
    ////        return;
    ////    }
    ////    Debug.Log("Successful register");
    ////    PlayerData data = new PlayerData();
    ////        data.username = UserName.text;
    ////        data.password = Password.text;
    ////        string json = JsonUtility.ToJson(data, true);
    ////        File.WriteAllText(Application.persistentDataPath + "/SaveGame.json", json);
        

    ////}
    




}
