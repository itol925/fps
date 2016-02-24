using System;
using System.Collections;
using System.Collections.Generic;

public interface IObserver {
    IList<string> ListNotificationInterests();
    void OnNotified(string message, object body);
}
