using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using AView = Android.Views.View;

namespace Xamarin.Forms.Platform.Android.Renderers
{
	public class StackLayoutRenderer : LinearLayout, IVisualElementRenderer
	{
		[Obsolete("This constructor is obsolete as of version 3.0. Please use ButtonRenderer(Context) instead.")]
		public StackLayoutRenderer() : base(Forms.Context)
		{
			Orientation = Orientation.Vertical;
		}

		public StackLayoutRenderer(Context context) : base(context)
		{
			Orientation = Orientation.Vertical;
			SetGravity(GravityFlags.Fill);
		}

		public VisualElement Element => null;

		public VisualElementTracker Tracker => null;

		public ViewGroup ViewGroup => this;

		public global::Android.Views.View View => this;

		public event EventHandler<VisualElementChangedEventArgs> ElementChanged;
		public event EventHandler<PropertyChangedEventArgs> ElementPropertyChanged;

		public SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
		{
			return new SizeRequest();
		}

		IElementController ElementController => Element as IElementController;

		[Obsolete("This constructor is obsolete as of version 3.0. Please use ButtonRenderer(Context) instead.")]
		public void SetElement(VisualElement telement)
		{
			var tu = telement as IElementController;

			foreach (Element child in tu.LogicalChildren)
				HandleChildAdded(Element, new ElementEventArgs(child));

			telement.ChildAdded += HandleChildAdded;
			telement.ChildRemoved += HandleChildRemoved;
			telement.ChildrenReordered += HandleChildrenReordered;

			ElementChanged?.Invoke(this, null);
			ElementPropertyChanged?.Invoke(this, null);

		}

		[Obsolete("This constructor is obsolete as of version 3.0. Please use ButtonRenderer(Context) instead.")]
		void HandleChildAdded(object sender, ElementEventArgs e)
		{
			var view = e.Element as VisualElement;

			if (view == null)
				return;

			IVisualElementRenderer renderer;
			Platform.SetRenderer(view, renderer = Platform.CreateRenderer(view));

			AView view2 = renderer as AView;

			if (view2.LayoutParameters is LinearLayout.LayoutParams)
			{
				(view2.LayoutParameters as LinearLayout.LayoutParams).Gravity = GravityFlags.FillVertical;
				(view2.LayoutParameters as LinearLayout.LayoutParams).Height = ViewGroup.LayoutParams.MatchParent;
				(view2.LayoutParameters as LinearLayout.LayoutParams).Width = ViewGroup.LayoutParams.MatchParent;
			}



			AddView(view2);
			
			/*IVisualElementRenderer renderer;
			Platform.SetRenderer(view, renderer = Platform.CreateRenderer(view));
			Control.Children.Add(renderer.GetNativeElement());*/

		}

		void HandleChildRemoved(object sender, ElementEventArgs e)
		{
			var view = e.Element as VisualElement;

			if (view == null)
				return;

			/*FrameworkElement native = Platform.GetRenderer(view)?.GetNativeElement() as FrameworkElement;
			if (native != null)
			{
				Control.Children.Remove(native);
				view.Cleanup();

			}*/

		}

		void HandleChildrenReordered(object sender, EventArgs e)
		{
		}
		
		public void SetLabelFor(int? id)
		{

		}

		public void UpdateLayout()
		{

		}
	}
}