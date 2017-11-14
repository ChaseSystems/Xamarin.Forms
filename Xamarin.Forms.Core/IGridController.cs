using Xamarin.Forms.Internals;

namespace Xamarin.Forms
{
	public interface IGridController
	{
#if !FORMS40
		void InvalidateMeasureInernalNonVirtual(InvalidationTrigger trigger);
#endif
	}
}