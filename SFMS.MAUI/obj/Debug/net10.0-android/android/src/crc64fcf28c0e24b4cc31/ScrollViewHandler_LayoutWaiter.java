package crc64fcf28c0e24b4cc31;


public class ScrollViewHandler_LayoutWaiter
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.ViewTreeObserver.OnGlobalLayoutListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGlobalLayout:()V:GetOnGlobalLayoutHandler:Android.Views.ViewTreeObserver+IOnGlobalLayoutListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Handlers.ScrollViewHandler+LayoutWaiter, Microsoft.Maui", ScrollViewHandler_LayoutWaiter.class, __md_methods);
	}

	public ScrollViewHandler_LayoutWaiter ()
	{
		super ();
		if (getClass () == ScrollViewHandler_LayoutWaiter.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Handlers.ScrollViewHandler+LayoutWaiter, Microsoft.Maui", "", this, new java.lang.Object[] {  });
		}
	}

	public void onGlobalLayout ()
	{
		n_onGlobalLayout ();
	}

	private native void n_onGlobalLayout ();

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
