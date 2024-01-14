using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetDeleteUser : LobbyPanelBase
{
    [Header("CreateNickNamePanel Vars")]
    [SerializeField] private TMP_InputField inp_ID;
   

    [SerializeField] private Button DeleteUserBtn;
    [SerializeField] private Button GetUserBtn;


    public override void InitPanel(LobbyUIManager lobbyUIManager)
    {
        base.InitPanel(lobbyUIManager);

        GetUserBtn.onClick.AddListener(OnGetUser);
        DeleteUserBtn.onClick.AddListener(OnDeleteUser);

    }


    private void OnDeleteUser()
    {
        if (!IsParseNumber().Item1)
            return;

        StartCoroutine(UserControllerClient.I.DeleteUser(IsParseNumber().Item2, (loginResponse) =>
        {
            

            if (loginResponse != null)
            {
                var result = loginResponse.result;
                Debug.Log(result.id);
                var user = new UserModel(result.id, result.userName, result.password, default);
                UserManager.I.UserModel = user;
            }
            else
            {
                Debug.Log("Kullanıcı silindi!");
            }
        }));
    }

    private void OnGetUser()
    {
        if (!IsParseNumber().Item1)
            return;

        StartCoroutine(UserControllerClient.I.GetUser(IsParseNumber().Item2, (loginResponse) =>
        {
            Debug.Log(loginResponse);

            if (loginResponse != null)
            {
                var result = loginResponse.result;
                Debug.Log(result.id);
                var user = new UserModel(result.id, result.userName, result.password,default);
                UserManager.I.UserModel = user;
            }
            else
            {
                Debug.LogError("Giriş başarısız!");
            }
        }));
    }

    private (bool,int) IsParseNumber()
    {
        string inputText = inp_ID.text;
       
        if (int.TryParse(inputText, out int result))
        {
            int prevID = result;
            Debug.Log("prevID: " + prevID);
            return (true, prevID);
        }

        return (false, default);
    }
}
