﻿/// This is Eduardo Costa AMVCC architecture code file.
/// Source: https://bitbucket.org/eduardo_costa/thelab-unity-mvc/overview
/// Do NOT edit this source code!

using UnityEngine;

#pragma warning disable 0109
#pragma warning disable 0108

namespace Assets.VirusAttackSource.AMVCC {

    /// <summary>
    /// Class that implements ColliderView features for any BaseApplication
    /// </summary>
    public class ColliderView : ColliderView<BaseApplication> { }

    /// <summary>
    /// Base class for collision related classes.
    /// </summary>
    public class ColliderView<T> : NotificationView<T> where T : BaseApplication {

        /// <summary>
        /// This View's Collider.
        /// </summary>
        new public Collider collider { get { return m_collider = AssertLocal<Collider>(m_collider); } }
        private Collider m_collider;

        /// <summary>
        /// Flags indicating the sub-category of notification.
        /// </summary>        
        public bool enter = true;
        public bool exit  = false;
        public bool stay  = false;

    }
}