using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCommand
{
    protected abstract BackendEvents Event { get; }
    public abstract string Endpoint { get; }
    public abstract byte[] GetRawData();
    //public abstract void OnSuccess(Response response);
    public abstract void OnFailure();
    public abstract bool ShouldRemoveSameType();
    public bool IsRetriedCommand { get; set; } = false;
}
