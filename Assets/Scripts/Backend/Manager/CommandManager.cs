using Cysharp.Threading.Tasks;
using Google.Protobuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager
{
    private readonly RequestSender _requestSender = new();
    public static CommandManager Instance { get; private set; }
    public CommandManager()
    {
        if (Instance != null)
        {
            Debug.LogWarning("You are trying to create another instance of COMMAND MANAGER. Ignoring...");
            return;
        }

        Instance = this;
    }

    public UniTask<FullResponse<TRes>> Send<TReq, TRes>(Command<TReq, TRes> command)
        where TReq : class, IMessage<TReq>
        where TRes : class, IMessage<TRes>
    {
        var completionSource = new UniTaskCompletionSource<FullResponse<TRes>>();
        command.Initialize(completionSource);

        //_requestSender.Send(command);

        return completionSource.Task;
    }
}
