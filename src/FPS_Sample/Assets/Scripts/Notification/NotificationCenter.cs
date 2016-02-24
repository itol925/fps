using System.Collections.Generic;

namespace SimpleFramework {
    public class NotificationCenter {
        private static NotificationCenter instance;
        public static NotificationCenter Instance {
            get {
                if (instance == null) {
                    instance = new NotificationCenter();
                }
                return instance;
            }
        }
        private NotificationCenter() { }

        private List<IObserver> _observes = new List<IObserver>();

        public void SendNotification(string message, object body) {
            foreach (var o in _observes) {
                IList<string> insterest = o.ListNotificationInterests();
                if (insterest.Contains(message)) {
                    o.OnNotified(message, body);
                }
            }
        }

        public void registerObserve(IObserver o) {
            _observes.Add(o);
        }
        public void removeObserve(IObserver o) {
            _observes.Remove(o);
        }
    }
}