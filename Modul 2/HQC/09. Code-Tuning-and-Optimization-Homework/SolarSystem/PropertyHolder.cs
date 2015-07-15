using System.Windows;

namespace Surfaces
{
	public class PropertyHolder<PropertyType, HoldingType> where HoldingType : DependencyObject
	{
		private readonly DependencyProperty _property;

		public PropertyHolder(string name, PropertyType defaultValue, PropertyChangedCallback propertyChangedCallback)
		{
			this._property =
				DependencyProperty.Register(
					name,
					typeof (PropertyType),
					typeof (HoldingType),
					new PropertyMetadata(defaultValue, propertyChangedCallback));
		}

		public DependencyProperty Property
		{
			get { return this._property; }
		}

		public PropertyType Get(HoldingType obj) { return (PropertyType) obj.GetValue(this._property); }
		public void Set(HoldingType obj, PropertyType value) { obj.SetValue(this._property, value); }
	}
}