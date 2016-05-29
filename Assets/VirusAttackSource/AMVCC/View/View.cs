/// This is Eduardo Costa AMVCC architecture code file.
/// Source: https://bitbucket.org/eduardo_costa/thelab-unity-mvc/overview
/// Do NOT edit this source code!

namespace VirusAttackSource.AMVCC {

    /// <summary>
    /// Base class for all View related classes.
    /// </summary>
    public class View : Element { }

    /// <summary>
    /// Base class for all View related classes.
    /// </summary>
    public class View<T> : View where T : BaseApplication {

        /// <summary>
        /// Returns app as a custom 'T' type.
        /// </summary>
        new public T app { get { return (T)base.app; } }
    }
}