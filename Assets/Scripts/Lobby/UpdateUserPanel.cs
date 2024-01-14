using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUserPanel : LobbyPanelBase
{
    [Header("CreateNickNamePanel Vars")]
    [SerializeField] private TMP_InputField inp_ID;
    [SerializeField] private TMP_InputField inp_UserName;
    [SerializeField] private TMP_InputField inp_Password;

    [SerializeField] private Button UpdateBtn;
   

    public override void InitPanel(LobbyUIManager lobbyUIManager)
    {
        base.InitPanel(lobbyUIManager);

        UpdateBtn.onClick.AddListener(OnUpdate);
       
    }


    private void OnUpdate()
    {
        if (!IsParseNumber().Item1) return;


        var nickName = inp_UserName.text;
        var password = inp_Password.text;

        var model = new UserRequestModel();

        model.UserName = nickName;
        model.Password = password;
      
        StartCoroutine(UserControllerClient.I.UpdateUser(IsParseNumber().Item2, model, (loginResponse) =>
        {
            if (loginResponse != null)
            {
                var result = loginResponse.result;
               
                Debug.Log("Kullanıcı adı: " + result.userName);
                Debug.Log("Kullanıcı token: " + result.userToken);

                var user = new UserModel(result.id, result.userName, result.password, result.userToken);
                UserManager.I.UserModel = user;

            }
            else
            {
               
                Debug.LogError("Giriş başarısız! ");
            }
        }));
    }

    private (bool, int) IsParseNumber()
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
