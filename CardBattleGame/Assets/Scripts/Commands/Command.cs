using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public static Queue<Command> commandQueue = new Queue<Command>();
    public static bool playingQueue = false;

    public virtual void AddToQueue()
    {
        commandQueue.Enqueue(this);
        if(!playingQueue)
        {
            PlayFirstCommandFromQueue();
        }
    }

    public virtual void StartCommandExecution()
    {
        // list of everything that we havae to do with this command (draw card, play a card, play spell effect, etc.)
        // there are 2 options of timing
        // #1. use tween sequences and call CommandExecutionComplete in OnComplete()
        // #2. use coroutines (IEnumerator) and WaitFor... to introduce delays, call CommandExecutionComplete()
    }

    public static void CommandExecutionComplete()
    {
        if(commandQueue.Count > 0)
        {
            PlayFirstCommandFromQueue();
        }
        else
        {
            playingQueue = false;
        }

        //if(TurnManager.Instance.whoseTurn != null)
        //{
        //    TurnManager.Instance.whoseTurn.HighlightPlayableCards();
        //}
    }

    public static void PlayFirstCommandFromQueue()
    {
        playingQueue = true;
        commandQueue.Dequeue().StartCommandExecution();
    }

    //public static bool CardDrawPending()
    //{
    //    foreach (Command command in commandQueue)
    //    {
    //        if(command is DrawACardCommand)
    //        {
    //            return true;
    //        }
    //    }

    //    return false;
    //}
}
