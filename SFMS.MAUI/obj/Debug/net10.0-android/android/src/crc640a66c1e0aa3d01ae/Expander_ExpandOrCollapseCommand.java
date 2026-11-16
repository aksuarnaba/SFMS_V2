package crc640a66c1e0aa3d01ae;


public class Expander_ExpandOrCollapseCommand
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.core.view.accessibility.AccessibilityViewCommand
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_perform:(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityViewCommand$CommandArguments;)Z:GetPerform_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityViewCommand_CommandArguments_Handler:AndroidX.Core.View.Accessibility.IAccessibilityViewCommandInvoker, Xamarin.AndroidX.Core\n" +
			"";
		mono.android.Runtime.register ("CommunityToolkit.Maui.Views.Expander+ExpandOrCollapseCommand, CommunityToolkit.Maui", Expander_ExpandOrCollapseCommand.class, __md_methods);
	}

	public Expander_ExpandOrCollapseCommand ()
	{
		super ();
		if (getClass () == Expander_ExpandOrCollapseCommand.class) {
			mono.android.TypeManager.Activate ("CommunityToolkit.Maui.Views.Expander+ExpandOrCollapseCommand, CommunityToolkit.Maui", "", this, new java.lang.Object[] {  });
		}
	}

	public boolean perform (android.view.View p0, androidx.core.view.accessibility.AccessibilityViewCommand.CommandArguments p1)
	{
		return n_perform (p0, p1);
	}

	private native boolean n_perform (android.view.View p0, androidx.core.view.accessibility.AccessibilityViewCommand.CommandArguments p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
