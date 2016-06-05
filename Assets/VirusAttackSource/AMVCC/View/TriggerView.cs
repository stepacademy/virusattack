/// This is Eduardo Costa AMVCC architecture code file.
/// Source: https://bitbucket.org/eduardo_costa/thelab-unity-mvc/overview
/// Do NOT edit this source code!

using UnityEngine;


namespace Assets.VirusAttackSource.AMVCC {

    /// <summary>
    /// Class that implements TriggerView features for any BaseApplication
    /// </summary>
    public class TriggerView : TriggerView<BaseApplication> { }

    /// <summary>
    /// View class that detects and notifies trigger related events.
    /// </summary>
    public class TriggerView<T> : ColliderView<T> where T : BaseApplication {

        /// <summary>
        /// Callbacks when a Trigger Collider suffers interaction.
        /// </summary>
        void OnTriggerEnter(Collider p_collider) { if (enter) Notify(notification + "@trigger.enter", p_collider); }
        void OnTriggerExit(Collider p_collider)  { if (exit)  Notify(notification + "@trigger.exit",  p_collider); }
        void OnTriggerStay(Collider p_collider)  { if (stay)  Notify(notification + "@trigger.stay",  p_collider); }

    }
}