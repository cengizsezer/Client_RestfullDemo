using BestHTTP;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CustomHTTPRequest
{
    private  Uri _baseUri = new("https://localhost:44397/");
    private string AllUsers = "api/users";


    public  void MakeRequest(string url)
    {
        HTTPRequest request = new HTTPRequest(_baseUri, OnRequestFinished);
        request.Send();
    }

    private  void OnRequestFinished(HTTPRequest request, HTTPResponse response)
    {
        if (request.Exception != null)
        {
            Debug.LogError("Request Exception: " + request.Exception.Message);
            return;
        }

        if (response.IsSuccess)
        {
            string jsonResponse = response.DataAsText;
            Debug.Log("Response: " + jsonResponse);

            // Burada yanıtı işleyebilir veya kaydedebilirsiniz.
            // Örnek olarak JSON'u bir nesneye dönüştürme:
            var responseObject = JsonUtility.FromJson<ResponseObject>(jsonResponse);

            if (responseObject != null)
            {
                // Yanıtı kullanarak yapılacak işlemleri gerçekleştirin.
                // Örnek olarak veriyi kaydetme:
                SaveData(responseObject);
            }
        }
        else
        {
            Debug.LogError("Request Failed: " + response.StatusCode.ToString() + " Message: " + response.Message);
        }
    }

    private  void SaveData(ResponseObject responseObject)
    {
        // Yanıtı kullanarak veriyi kaydetmek için gerekli işlemleri yapın.
        // Örnek olarak verinin işlenmesi veya kaydedilmesi gibi işlemler burada olabilir.
    }

    // Örnek bir yanıt sınıfı
    [System.Serializable]
    public class ResponseObject
    {
        // Yanıtta alınan verileri tanımlayın.
        // Örnek olarak:
        public int UserID;
        public string UserName;
        public string Password;
        public string UserToken;
        // ... diğer veri alanları
    }
}
