using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.VirusAttackSource.Game {

    internal sealed class UnityHierarchyComponentBuilder {

        private string     _name;
        private Transform  _parent;
        private List<Type> _components;

        internal UnityHierarchyComponentBuilder SetName(string name) {
            _name = name;
            return this;
        }

        internal UnityHierarchyComponentBuilder SetParent(Transform parent) {
            _parent = parent;
            return this;
        }

        internal UnityHierarchyComponentBuilder AddComponent(Type component) {

            if (_components == null)
                _components = new List<Type>();

            _components.Add(component);
            return this;
        }

        internal GameObject Build() {

            GameObject unityHierarchyComponent = new GameObject();

            if (_name != null)
                unityHierarchyComponent.name = _name;

            if (_parent != null)
                unityHierarchyComponent.transform.SetParent(_parent);

            if (_components != null) {
                foreach (var component in _components) {
                    unityHierarchyComponent.AddComponent(component);
                }
            }
            return unityHierarchyComponent;
        }
    }
}