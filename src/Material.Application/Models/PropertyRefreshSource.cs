using System.Collections;
using System.Collections.Generic;

namespace Material.Application.Models
{
    public class PropertyRefreshSource : IEnumerable<string>
    {
        private readonly Model model;
        private readonly List<string> properties = new List<string>();

        public PropertyRefreshSource(Model model)
        {
            this.model = model;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return properties.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(string propertyName)
        {
            if (!properties.Contains(propertyName))
            {
                properties.Add(propertyName);
            }
        }

        public bool Remove(string propertyName)
        {
            return properties.Remove(propertyName);
        }

        public void Refresh()
        {
            foreach (var property in properties)
            {
                model.NotifyPropertyChanged(property);
            }
        }
    }
}
