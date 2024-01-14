using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Protobuf;

public abstract class Command<TReq, TRes> : BaseCommand
        where TReq : class, IMessage<TReq>
        where TRes : class, IMessage<TRes>
{
    private UniTaskCompletionSource<FullResponse<TRes>> _completionSource;
    private readonly TReq _request;
    private readonly DateTime _requestTime;
    public bool RetriedCommand { get; set; }

    protected Command(TReq request)
    {
        _request = request;
        _requestTime = DateTime.Now;
    }

    public void Initialize(UniTaskCompletionSource<FullResponse<TRes>> completionSource)
    {
        _completionSource = completionSource;
    }

    public override byte[] GetRawData()
    {
        return _request.ToByteArray();
    }

    //public override void OnSuccess(Response response)
    //{
    //    var expectedResponse = response.Data.ToByteArray().Deserialize<TRes>();

    //    if (expectedResponse != null)
    //    {
    //        var fullResponse = new FullResponse<TRes>
    //        {
    //            Data = expectedResponse,
    //            ServerTime = response.ServerTime,
    //            DifferenceTime = TimeUtil.GetDifferenceTime(_requestTime, DateTime.Now)
    //        };

    //        _completionSource.TrySetResult(fullResponse);
    //        EventManager<FullResponse<TRes>>.Execute(Event, fullResponse);
    //    }
    //    else
    //    {
    //        OnFailure();
    //    }
    //}

    public override void OnFailure()
    {
        _completionSource.TrySetResult(null);
    }
}

public class FullResponse<T> where T : class
{
    public T Data { get; set; }
    public long ServerTime { get; set; }
    public float DifferenceTime { get; set; }
}
