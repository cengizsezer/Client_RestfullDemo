using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetAllDeleteAllPanel : LobbyPanelBase
{
    [Header("GetAllDeleteAllPanel Vars")] 
    [SerializeField] private Button GetAllBtn;
    [SerializeField] private Button DeleteAllBtn;
   
    
    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);
        GetAllBtn.onClick.AddListener(GetAll);
        DeleteAllBtn.onClick.AddListener(DeleteAll);

    }

    private void GetAll()
    {
        StartCoroutine(UserControllerClient.I.GetAllUsers((loginResponse) =>
        {
            Debug.Log(loginResponse);
            if (loginResponse != null)
            {
                UserManager.I.lsUsers.Clear();
                foreach (var result in loginResponse.result)
                {
                    Debug.Log(result);
                    UserModel userModel = new UserModel(result.id, result.userName, result.password, result.userToken);
                   
                    UserManager.I.lsUsers.Add(userModel);
                }

                Debug.Log("Tüm kullanıcılar başarıyla alındı!");
            }
            else
            {
                Debug.LogError("Giriş başarısız!");
            }
        }));
    }



    //private void GetAll()
    //{
    //    StartCoroutine(UserControllerClient.I.GetAllUsers((loginResponse) =>
    //    {
    //        Debug.Log(loginResponse);
    //        if (loginResponse != null)
    //        {

    //            var lsPrev = loginResponse.ToList();

    //            foreach (var response in lsPrev)
    //            {
    //                UserModel userModel = new(response.result.id,response.result.userName,response.result.password,response.result.userToken);
    //                UserManager.I.lsUsers.Add(userModel);
    //            }

    //        }
    //        else
    //        {
    //            Debug.Log("girdi3");
    //            Debug.LogError("Giriş başarısız! ");
    //        }
    //    }));
    //}

    private void DeleteAll()
    {
        StartCoroutine(UserControllerClient.I.DeleteAllUser());
      
    }
}