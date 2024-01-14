using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateNickNamePanel : LobbyPanelBase
{
    [Header("CreateNickNamePanel Vars")]
    [SerializeField] private TMP_InputField inp_UserName;
    [SerializeField] private TMP_InputField inp_Password;

    [SerializeField] private Button createNicknameBtn;
    private const int MAX_CHAR_FOR_NICKNAME = 2;

    public override void InitPanel(LobbyUIManager lobbyUIManager)
    {
        base.InitPanel(lobbyUIManager);
        createNicknameBtn.interactable = false;
        createNicknameBtn.onClick.AddListener(OnClickCreate);
        inp_UserName.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string arg0)
    {
        createNicknameBtn.interactable = arg0.Length >= MAX_CHAR_FOR_NICKNAME;
    }

    private void OnClickCreate()
    {
        var nickName = inp_UserName.text;
        var password = inp_Password.text;

        var model = new UserRequestModel();
       
        model.UserName = nickName;
        model.Password = password;
        Debug.Log("girdi1");
        StartCoroutine(UserControllerClient.I.CreateUser(model, (loginResponse) =>
        {
            if (loginResponse != null )
            {
                var result = loginResponse.result;
                Debug.Log("girdi2");
                Debug.Log("Kullanıcı adı: " + result.userName);
                Debug.Log("Kullanıcı token: " + result.userToken);
               
                var user = new UserModel(result.id, result.userName, result.password, result.userToken);
                UserManager.I.UserModel = user;

            }
            else
            {
                Debug.Log("girdi3");
                Debug.LogError("Giriş başarısız! ");
            }
        }));
    }

}