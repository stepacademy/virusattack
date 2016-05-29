/// This is Eduardo Costa AMVCC architecture code file.
/// Source: https://bitbucket.org/eduardo_costa/thelab-unity-mvc/overview
/// Do NOT edit this source code!

using UnityEngine.EventSystems;


namespace VirusAttackSource.AMVCC {

    /// <summary>
    /// Extension to support generic applications.
    /// </summary>
    public class DropView<T> : DragView where T : BaseApplication {

        /// <summary>
        /// Returns app as a custom 'T' type.
        /// </summary>
        new public T app { get { return (T)base.app; } }
    }

    /// <summary>
    /// Base class for all Mouse Drop features related classes.
    /// </summary>
    public class DropView : NotificationView, IDropHandler {

        /// <summary>
        /// Init.
        /// </summary>
        void Start() { }

        /// <summary>
        /// Handles the drop callback.
        /// </summary>
        public void OnDrop(PointerEventData e) {
            Notify(notification + "@drop", e);
        }
    }
}