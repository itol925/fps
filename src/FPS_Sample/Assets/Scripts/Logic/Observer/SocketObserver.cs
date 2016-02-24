using SimpleFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SocketObserver : IObserver {
    private IList<string> insterestNotif;

    public SocketObserver() { 
        
    }

	public void OnNotified(string massage, object body) {
        switch (massage) {
            case NotiConst.DISPATCH_MESSAGE:
                if (body == null) 
                    return;

                KeyValuePair<int, ByteBuffer> data = (KeyValuePair<int, ByteBuffer>)body;
                switch (data.Key) {
                    default: Util.CallMethod("Network", "OnSocket", data.Key, data.Value); 
                    break;
                }
            break;
        }
    }

    public IList<string> ListNotificationInterests() {
        if (insterestNotif == null) { 
            insterestNotif = new List<string>(){ 
                NotiConst.DISPATCH_MESSAGE,
            };
        }
        return insterestNotif;
    }
}

