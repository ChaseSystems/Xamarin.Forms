using System;

namespace Xamarin.Forms
{
	public interface ILayout
	{
#if !FORMS40
		event EventHandler LayoutChanged;
#endif
	}
}