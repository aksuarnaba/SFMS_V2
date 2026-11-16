package crc64308147b72ef9fa87;


public class NavigationBar_NavigationBarOverlayInsetsListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnApplyWindowInsetsListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onApplyWindowInsets:(Landroid/view/View;Landroid/view/WindowInsets;)Landroid/view/WindowInsets;:GetOnApplyWindowInsets_Landroid_view_View_Landroid_view_WindowInsets_Handler:Android.Views.View+IOnApplyWindowInsetsListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("CommunityToolkit.Maui.PlatformConfiguration.AndroidSpecific.NavigationBar+NavigationBarOverlayInsetsListener, CommunityToolkit.Maui", NavigationBar_NavigationBarOverlayInsetsListener.class, __md_methods);
	}

	public NavigationBar_NavigationBarOverlayInsetsListener ()
	{
		super ();
		if (getClass () == NavigationBar_NavigationBarOverlayInsetsListener.class) {
			mono.android.TypeManager.Activate ("CommunityToolkit.Maui.PlatformConfiguration.AndroidSpecific.NavigationBar+NavigationBarOverlayInsetsListener, CommunityToolkit.Maui", "", this, new java.lang.Object[] {  });
		}
	}

	public android.view.WindowInsets onApplyWindowInsets (android.view.View p0, android.view.WindowInsets p1)
	{
		return n_onApplyWindowInsets (p0, p1);
	}

	private native android.view.WindowInsets n_onApplyWindowInsets (android.view.View p0, android.view.WindowInsets p1);

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
