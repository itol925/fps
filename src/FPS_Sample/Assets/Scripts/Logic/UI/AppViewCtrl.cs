using SimpleFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AppViewCtrl {
    private AppView appView;

    public AppViewCtrl(AppView view) { 
        appView = view;
    }

    public void UpdateMessage(string data) {
        appView.Message = data;
    }

    public void UpdateExtract(string data) {
        appView.Message = data;
    }

    public void UpdateDownload(string data) {
        appView.Message = data;
    }

    public void UpdateProgress(string data) {
        appView.Message = data;
    }
}

