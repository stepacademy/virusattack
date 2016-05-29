/// This is Eduardo Costa AMVCC architecture code file.
/// Source: https://bitbucket.org/eduardo_costa/thelab-unity-mvc/overview
/// Do NOT edit this source code!

namespace VirusAttackSource.AMVCC {

    /// <summary>
    /// Base class for all View with notifications.
    /// </summary>
    public class NotificationView : NotificationView<BaseApplication> { }

    /// <summary>
    /// Base class for all View with notification features.
    /// </summary>
    public class NotificationView<T> : View<T> where T : BaseApplication {

        /// <summary>
        /// Fixed notification. Can be empty.
        /// </summary>
        public string notification;

    }
}