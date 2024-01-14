using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedCommandHandler
{
    private RequestSender _requestSender;
    private List<BaseCommand> _failedCommandList = new List<BaseCommand>();

    public FailedCommandHandler(RequestSender requestSender)
    {
        _requestSender = requestSender;
        //EventManager.Subscribe(NetworkEvents.OnGoodPingReceived, ReSendQueuedCommands);
    }

    public void AddFailedCommandToList(BaseCommand command)
    {
        _failedCommandList.Add(command);
    }

    public void ReSendQueuedCommands()
    {
        while (_failedCommandList.Count > 0)
        {
            BaseCommand failedCommand = _failedCommandList[0];


            failedCommand.IsRetriedCommand = true;
            //_requestSender.Send(failedCommand);

            _failedCommandList.Remove(failedCommand);
        }
    }

    public void RemoveSameTypeOfCommand(BaseCommand commandBase)
    {
        if (commandBase.ShouldRemoveSameType() && !commandBase.IsRetriedCommand)
        {
            _failedCommandList.RemoveAll(command => command.Endpoint == commandBase.Endpoint);
        }
    }

}
