using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public class GameObject
    {
        private List<IComponent> _components;
        public Scene SceneParent { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }

            #pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public GameObject(string name, string tag)
            #pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        {
            Name = name;
            Tag = tag;
            _components = new List<IComponent>();
        }

        public IComponent AddComponent(IComponent component)
        {
            component.Parent = this;
            _components.Add(component);
            return component;
        }
        public T GetComponent<T>() where T : class, IComponent
        {
                #pragma warning disable CS8603 // Possível retorno de referência nula.
            return _components.OfType<T>().FirstOrDefault();
                #pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public void Start()
        {
            foreach (var com in _components)
            {
                com.Start();
            }
        }
        public void Update()
        {
            foreach (var com in _components)
            {
                com.Update();
            }
        }
        public void Render()
        {
            foreach (var com in _components.OfType<IRenderable>())
            {
                com.Render();
            }
        }
    }
}
