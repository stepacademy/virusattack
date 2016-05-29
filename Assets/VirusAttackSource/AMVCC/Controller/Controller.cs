/// This is Eduardo Costa AMVCC architecture code file.
/// Source: https://bitbucket.org/eduardo_costa/thelab-unity-mvc/overview
/// Do NOT edit this source code!

using UnityEngine;


namespace VirusAttackSource.AMVCC {

    /// <summary>
    /// Base class for all Controllers in the application.
    /// </summary>
    public class Controller : Element {

        /// <summary>
        /// Handles notifications sent from any Element in the currently running scene.
        /// </summary>
        virtual public void OnNotification(string p_event, Object p_target, params object[] p_data) { }
    }

    /// <summary>
    /// Base class for all Controller related classes.
    /// </summary>
    public class Controller<T> : Controller where T : BaseApplication {

        /// <summary>
        /// Returns app as a custom 'T' type.
        /// </summary>
        new public T app { get { return (T)base.app; } }
    }

}