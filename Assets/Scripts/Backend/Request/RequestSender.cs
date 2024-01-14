using BestHTTP;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestSender : MonoBehaviour
{
    private readonly Uri _baseUri;

    private FailedCommandHandler failedCommandHandler;

    public RequestSender()
    {
        _baseUri = new("https://localhost:44397/");
        failedCommandHandler = new FailedCommandHandler(this);
    }

    //public void Send(BaseCommand command)
    //{
    //    HTTPManager.Setup();
    //    AsyncStartSendCommand(command);
    //}

    //private async void AsyncStartSendCommand(BaseCommand command)
    //{
    //    var commandUri = new Uri(_baseUri, command.Endpoint);

    //    var request = new HTTPRequest(commandUri, HTTPMethods.Post)
    //    {
    //        RawData = command.GetRawData(),
    //        ConnectTimeout = TimeSpan.FromSeconds(5),
    //        Timeout = TimeSpan.FromSeconds(10),
    //        MaxRetries = 1
    //    };

    //    request.AddHeader("Authorization", DataAccessor.Instance.LocalGameData.User.UserToken);
    //    request.AddHeader("Accept", "application/x-protobuf");
    //    request.AddHeader("Content-Type", "application/x-protobuf");

    //    try
    //    {
    //        var response = await request.GetHTTPResponseAsync().AsUniTask();

    //        // LogSystemManager.Log("Backend responded to request.", "Backend");

    //        var backendResponse = response.Data.Deserialize<Response>();
    //        if (backendResponse == null)
    //        {
    //            Debug.LogError("Backend can't deserialize the response." + "Backend");
    //            command.OnFailure();
    //            return;
    //        }


    //        //var responseState = HandleResultCode(backendResponse.ResultCode);
    //        //if (!responseState)
    //        //{
    //        //    command.OnFailure();
    //        //    return;
    //        //}

    //        command.OnSuccess(backendResponse);
    //        failedCommandHandler.RemoveSameTypeOfCommand(command);

    //    }
    //    catch (Exception e)
    //    {
    //        HandleFailedRequest(request);
    //        command.OnFailure();
    //        failedCommandHandler.AddFailedCommandToList(command);
    //    }
    //}

    //private void HandleFailedRequest(HTTPRequest request)
    //{
    //    switch (request.State)
    //    {
    //        case HTTPRequestStates.Error:
    //            Debug.LogError("Backend failed with error. " + (request.Exception != null ? (request.Exception.Message + "\n" + request.Exception.StackTrace) : "No Exception"), "Backend");
    //            break;
    //        case HTTPRequestStates.Aborted:
    //            Debug.LogError("User aborted waiting backend request." + "Backend");
    //            break;
    //        case HTTPRequestStates.ConnectionTimedOut:
    //            Debug.LogError("Backend timed out for request." + "Backend");
    //            break;
    //        case HTTPRequestStates.TimedOut:
    //            Debug.LogError("Backend processing the Request timed out." + "Backend");
    //            break;
    //        default:
    //            Debug.LogError($"Unexpected state for RequestState: {request.State}" + "Backend");
    //            break;
    //    }
    //}

    //private bool HandleResultCode(ResultCodes resultCode)
    //{
    //    switch (resultCode)
    //    {
    //        //case ResultCodes.ResultSuccess:
    //        //    //                    LogSystemManager.Log("Backend confirms request was received.", "Backend");
    //        //    return true;
    //        //case ResultCodes.ResultFailInvalidToken:
    //        //    Debug.LogError("Backend rejects request because user token is invalid." + "Backend");
    //        //    return false;
    //        //case ResultCodes.ResultFailInvalidDeviceId:
    //        //    Debug.LogError("Backend rejects request because user device id is invalid." + "Backend");
    //        //    return false;
    //        //case ResultCodes.ResultFailInvalidUserId:
    //        //    Debug.LogError("Backend rejects request because user id is invalid." + "Backend");
    //        //    return false;
    //        //case ResultCodes.ResultDeletedUser:
    //        //    Debug.LogError("Backend rejects request because user is deleted." + "Backend");
    //        //    EventManager.Execute(BackendEvents.OnDeletedUser);
    //        //    return false;
    //        //case ResultCodes.ResultFailGeneral:
    //        //default:
    //        //    Debug.LogError($"Backend Request failed: Unknown problem. ResultCode: {resultCode}" + "Backend");
    //            return false;
    //    }
    //}
}
