using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserModel
{
    [SerializeField] private string UserName = string.Empty;
    [SerializeField] private string Password = string.Empty;
    [SerializeField] private int ID = default;

    private const string USER_TOKEN_KEY = "USER_TOKEN";
    [SerializeField] private string UserToken = string.Empty;

    public UserModel(int ID,string USERNAME, string PASSWORD,string TOKEN)
    {
        SetUserToken(ID,USERNAME,PASSWORD,TOKEN);
    }

    public string GetUserToken() => UserToken;
    public void SetUserToken(int id,string username,string password,string token)
    {
        ID = id;
        UserName = username;
        Password = password;
        UserToken = token;
        SaveUserToken(token);

    }
    private void SaveUserToken(string userToken)
    {
        DataSaver.SetData(USER_TOKEN_KEY, userToken);
    }



}

[System.Serializable]
public class UserModelData
{
    public UserModelResult result;  
    public int id;
    public string exception;
    public int status;
    public bool isCanceled;
    public bool isCompleted;
    public bool isCompletedSuccessfully;
    public int creationOptions;
    public object asyncState;
    public bool isFaulted;
}

[System.Serializable]
public class UserModelResult
{
    public int id;
    public string userName;
    public string password;
}


[System.Serializable]
public class UserRequestModel
{
    public int Id;
    public string UserName;
    public string Password;
}


[System.Serializable]
public class LoginResponseData
{
    public int id;
    public string userName;
    public string userToken;
    public string password;
}

[System.Serializable]
public class LoginResponseModel
{
    public LoginResponseData result;
    public int id;
    public string exception;
    public int status;
    public bool isCanceled;
    public bool isCompleted;
    public bool isCompletedSuccessfully;
    public int creationOptions;
    public object asyncState;
    public bool isFaulted;

    // Burada gerekli diğer özellikler...
}

[System.Serializable]
public class AllUsersModel
{
    public List<LoginResponseData> result;

    //from resaulttan dönenler
    public int id;
    public string exception;
    public int status;
    public bool isCanceled;
    public bool isCompleted;
    public bool isCompletedSuccessfully;
    public int creationOptions;
    public object asyncState;
    public bool isFaulted;
}


