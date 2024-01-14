using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class UserControllerClient : Singleton<UserControllerClient>
{
    private readonly string baseUrl = "https://localhost:7296/api/users";
    public IEnumerator CreateUser(UserRequestModel model, System.Action<LoginResponseModel> callback)
    {
        // Model verisini JSON'a dönüştür
        string jsonData = JsonUtility.ToJson(model);

        // JSON veriyi cihazın kalıcı veri yoluna kaydet (isteğin yapıldığını doğrulamak için)
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
        Debug.Log("JSON Data: " + jsonData);

        // Base URL ve isteğin yapılacağı URL'yi birleştir
        string requestUrl = baseUrl; // Örnek bir API rotası

        // UnityWebRequest ile POST isteği oluştur
        using (UnityWebRequest www = new UnityWebRequest(requestUrl, "POST"))
        {
            // İstek başlıklarını ayarla
            www.SetRequestHeader("Content-Type", "application/json");

            // JSON veriyi isteğe ekle
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            // İsteği gönder ve yanıtı bekle
            yield return www.SendWebRequest();

            // Yanıtın durumunu kontrol et
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
                callback?.Invoke(null);
            }
            else
            {
                // Başarılı yanıtı al, LoginResponseModel'e dönüştür ve callback'i çağır
                string response = www.downloadHandler.text;
                Debug.Log(response);
                LoginResponseModel loginResponse = JsonUtility.FromJson<LoginResponseModel>(response);
                callback?.Invoke(loginResponse);
            }
        }
    }

    public IEnumerator GetAllUsers(System.Action<AllUsersModel> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(baseUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
                callback?.Invoke(null);
            }
            else
            {
                string response = www.downloadHandler.text;
                Debug.Log(response);


                AllUsersModel modelData = JsonUtility.FromJson<AllUsersModel>(response);

                Debug.Log(modelData);
                callback?.Invoke(modelData);
            }
        }
    }

    public IEnumerator GetUser(int id, System.Action<UserModelData> callback)
    {
        string url = $"{baseUrl}/{id}";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
                callback?.Invoke(null);
            }
            else
            {
                string response = www.downloadHandler.text;
                Debug.Log(response);
                UserModelData loginResponse = JsonUtility.FromJson<UserModelData>(response);
                Debug.Log(loginResponse.result);
                callback?.Invoke(loginResponse);
            }
        }
    }
    public IEnumerator DeleteUser(int id, System.Action<UserModelData> callback)
    {
        string url = $"{baseUrl}/{id}";

        using (UnityWebRequest www = UnityWebRequest.Delete(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
                callback?.Invoke(null);
            }
            else
            {
                if (www.downloadHandler != null)
                {
                    Debug.Log(www.downloadHandler);
                    string response = www.downloadHandler.text;
                    Debug.Log(response);
                    UserModelData loginResponse = JsonUtility.FromJson<UserModelData>(response);
                    Debug.Log(loginResponse.result);
                    callback?.Invoke(loginResponse);
                }
                else
                {
                    //Debug.LogError("Error: Download handler is null.");
                    callback?.Invoke(null);
                }
            }
        }
    }
    public IEnumerator UpdateUser(int id, UserRequestModel model, System.Action<LoginResponseModel> callback)
    {
        string url = $"{baseUrl}/{id}";

        // Model verisini JSON'a dönüştür
        string jsonData = JsonUtility.ToJson(model);

        // JSON veriyi cihazın kalıcı veri yoluna kaydet (isteğin yapıldığını doğrulamak için)
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Data.json", jsonData);
        Debug.Log("JSON Data: " + jsonData);

        using (UnityWebRequest www = UnityWebRequest.Put(url, jsonData))
        {
            // İstek başlıklarını ayarla
            www.SetRequestHeader("Content-Type", "application/json");

            // JSON veriyi isteğe ekle
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            // İsteği gönder ve yanıtı bekle
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
                callback?.Invoke(null);
            }
            else
            {
                string response = www.downloadHandler.text;
                Debug.Log(response);
                LoginResponseModel loginResponse = JsonUtility.FromJson<LoginResponseModel>(response);
                callback?.Invoke(loginResponse);
            }
        }
    }

    public IEnumerator DeleteAllUser()
    {

        using (UnityWebRequest www = UnityWebRequest.Delete(baseUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
               
            }
            else
            {
                if (www.downloadHandler != null)
                {
                    
                }
                else
                {
                    Debug.Log("Tüm kayıt silindi");
                   
                }
            }
        }
    }
}

