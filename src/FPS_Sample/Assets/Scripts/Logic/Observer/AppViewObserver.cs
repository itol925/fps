using SimpleFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AppViewObserver : IObserver{
    private AppViewCtrl appViewCtrl;
    private IList<string> insterestNotif;

    public AppViewObserver() { 
        GameObject gameMgr = GameObject.Find("GlobalGenerator");
        AppView appView = gameMgr.GetComponent<AppView>();
        appViewCtrl = new AppViewCtrl(appView);
    }

	public void OnNotified(string massage, object body) {
        switch (massage) {
            case NotiConst.UPDATE_MESSAGE:      //更新消息
                appViewCtrl.UpdateMessage(body.ToString());
            break;
            case NotiConst.UPDATE_EXTRACT:      //更新解压
                appViewCtrl.UpdateExtract(body.ToString());
            break;
            case NotiConst.UPDATE_DOWNLOAD:     //更新下载
                appViewCtrl.UpdateDownload(body.ToString());
            break;
            case NotiConst.UPDATE_PROGRESS:     //更新下载进度
                appViewCtrl.UpdateProgress(body.ToString());
            break;
        }
    }

    public IList<string> ListNotificationInterests() {
        if (insterestNotif == null) { 
            insterestNotif = new List<string>(){ 
                NotiConst.UPDATE_MESSAGE,
                NotiConst.UPDATE_EXTRACT,
                NotiConst.UPDATE_DOWNLOAD,
                NotiConst.UPDATE_PROGRESS,
            };
        }
        return insterestNotif;
    }
}
