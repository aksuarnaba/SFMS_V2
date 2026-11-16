package crc645d80431ce5f73f11;


public class GridLayoutSpanSizeLookup
	extends androidx.recyclerview.widget.GridLayoutManager.SpanSizeLookup
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getSpanSize:(I)I:GetGetSpanSize_IHandler\n" +
			"n_getSpanIndex:(II)I:GetGetSpanIndex_IIHandler\n" +
			"n_getSpanGroupIndex:(II)I:GetGetSpanGroupIndex_IIHandler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Controls.Handlers.Items.GridLayoutSpanSizeLookup, Microsoft.Maui.Controls", GridLayoutSpanSizeLookup.class, __md_methods);
	}

	public GridLayoutSpanSizeLookup ()
	{
		super ();
		if (getClass () == GridLayoutSpanSizeLookup.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Controls.Handlers.Items.GridLayoutSpanSizeLookup, Microsoft.Maui.Controls", "", this, new java.lang.Object[] {  });
		}
	}

	public int getSpanSize (int p0)
	{
		return n_getSpanSize (p0);
	}

	private native int n_getSpanSize (int p0);

	public int getSpanIndex (int p0, int p1)
	{
		return n_getSpanIndex (p0, p1);
	}

	private native int n_getSpanIndex (int p0, int p1);

	public int getSpanGroupIndex (int p0, int p1)
	{
		return n_getSpanGroupIndex (p0, p1);
	}

	private native int n_getSpanGroupIndex (int p0, int p1);

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
