using UnityEngine;


namespace Assets.VirusAttackSource.Utilities {

    public sealed class ProportionalScaler {

        public Vector3 ScaleAtX(Vector3 oldScale, float newScaleX) {

            float ratio = newScaleX > oldScale.x ? newScaleX / oldScale.x : oldScale.x / newScaleX;
            return new Vector3(oldScale.x * ratio, oldScale.y * ratio, oldScale.z * ratio);
        }

        public Vector3 ScaleAtY(Vector3 oldScale, float newScaleY) {

            float ratio = newScaleY > oldScale.y ? newScaleY / oldScale.y : oldScale.y / newScaleY;
            return new Vector3(oldScale.x * ratio, oldScale.y * ratio, oldScale.z * ratio);
        }

        public Vector3 ScaleAtZ(Vector3 oldScale, float newScaleZ) {

            float ratio = newScaleZ > oldScale.z ? newScaleZ / oldScale.z : oldScale.z / newScaleZ;
            return new Vector3(oldScale.x * ratio, oldScale.y * ratio, oldScale.z * ratio);
        }
    }
}